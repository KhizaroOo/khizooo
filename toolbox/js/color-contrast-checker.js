$(document).ready(function () {
    const $foregroundColorPicker = $('#ccc-foreground');
    const $backgroundColorPicker = $('#ccc-background');
    const $foregroundHexInput = $('#ccc-foregroundHex');
    const $backgroundHexInput = $('#ccc-backgroundHex');
    const $fontsSelector = $("#font-selector");

    const $preview = $('#ccc-preview');
    const $contrastResult = $('#ccc-contrastResult');

    function hexToRGB(hex) {
        let r = parseInt(hex.slice(1, 3), 16);
        let g = parseInt(hex.slice(3, 5), 16);
        let b = parseInt(hex.slice(5, 7), 16);
        return { r, g, b };
    }

    function rgbToHsl(r, g, b) {
        // Convert RGB to HSL
        r /= 255; g /= 255; b /= 255;
        const max = Math.max(r, g, b);
        const min = Math.min(r, g, b);
        let h, s, l = (max + min) / 2;

        if (max === min) {
            h = s = 0; // achromatic
        } else {
            const d = max - min;
            s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
            switch (max) {
                case r: h = (g - b) / d + (g < b ? 6 : 0); break;
                case g: h = (b - r) / d + 2; break;
                case b: h = (r - g) / d + 4; break;
            }
            h /= 6;
        }
        return { h: Math.round(h * 360), s, l };
    }

    function updatePreviewAndContrast() {
        const fgColor = $foregroundHexInput.val();
        const bgColor = $backgroundHexInput.val();
        $preview.css({ color: fgColor, backgroundColor: bgColor });
        CompareColors();
    }

    function CompareColors() {
            let ResultColor, Message, Classes;
            const rgbA = hexToRGB($foregroundHexInput.val());
            const rgbB = hexToRGB($backgroundHexInput.val());

            // Calculate RGB distance
            const rgbDistance = Math.sqrt(
                Math.pow(rgbA.r - rgbB.r, 2) +
                Math.pow(rgbA.g - rgbB.g, 2) +
                Math.pow(rgbA.b - rgbB.b, 2)
            );

            // Calculate HSL values
            const hslA = rgbToHsl(rgbA.r, rgbA.g, rgbA.b);
            const hslB = rgbToHsl(rgbB.r, rgbB.g, rgbB.b);

            // Calculate HSL differences
            const hueDiff = Math.abs(hslA.h - hslB.h) / 360 * 100;
            const saturationDiff = Math.abs(hslA.s - hslB.s) * 100;
            const lightnessDiff = Math.abs(hslA.l - hslB.l) * 100;

            // Calculate luminance
            const luminanceA = (0.299 * rgbA.r + 0.587 * rgbA.g + 0.114 * rgbA.b) / 255;
            const luminanceB = (0.299 * rgbB.r + 0.587 * rgbB.g + 0.114 * rgbB.b) / 255;

           // Calculate Contrast Ratio
            const contrastRatio = luminanceA > luminanceB
                ? (luminanceA + 0.05) / (luminanceB + 0.05)
                : (luminanceB + 0.05) / (luminanceA + 0.05);

                if (contrastRatio >= 21) {
                    ResultColor = 1;
                    Message = "Your colors contrast is at the maximum possible level. Ideal for all viewers under any conditions.";
                }
                else if (contrastRatio >= 15) {
                    ResultColor = 1;
                    Message = "Extremely high contrast. Exceeds the highest accessibility standards.";
                }
                else if (contrastRatio > 8) {
                    ResultColor = 1;
                    Message = "Superb contrast. Far exceeds accessibility standards for any text size.";
                }
                else if (contrastRatio >= 7) {
                    ResultColor = 2;
                    Message = "Excellent contrast. Excellent for all text sizes, surpasses WCAG AAA standards. Excellent readability for all users.";
                }
                else if (contrastRatio >= 4.5) {
                    ResultColor = 3;
                    Message = "Good for all text sizes. Meets WCAG AA for normal text and AAA for large text. Sufficient for AA standards but not AAA. Good for most users.";
                }
                else if (contrastRatio >= 3.1) {
                    ResultColor = 3;
                    Message = "Improvements advised. Meets minimum WCAG AA standards for large text. Consider improving for broader accessibility. Acceptable for large text but not for normal text.";
                }
                else {
                    ResultColor = 4;
                    Message = "Strongly consider enhancing contrast. Fails WCAG AA standards for all text sizes. Contrast too low for accessible design. Not recommended for any text size.";
                }

                ColorSetterCheck($('#ccc-AA'), contrastRatio > 4.5);
                ColorSetterCheck($('#ccc-AAA'), contrastRatio > 7.0);
                ColorSetterCheck($('#ccc-AA18PT'), contrastRatio > 3.0);
                ColorSetterCheck($('#ccc-AAA18PT'), contrastRatio > 4.5);
                ColorSetterCheck($('#ccc-COLORS'), contrastRatio > 3.26);
                ColorSetterCheck($('#ccc-COLORDIFF'), contrastRatio > 5.0);

                Classes = ResultColor === 1 || ResultColor === 2 ?
            "alert fade alert-simple alert-success alert-dismissible text-left font__family-montserrat font__size-16 font__weight-light brk-library-rendered rendered show" :
            ResultColor === 3 ?
                "alert fade alert-simple alert-warning alert-dismissible text-left font__family-montserrat font__size-16 font__weight-light brk-library-rendered rendered show" :
                "alert fade alert-simple alert-danger alert-dismissible text-left font__family-montserrat font__size-16 font__weight-light brk-library-rendered rendered show";

            $contrastResult.html(`<div class="${Classes}"><p class="text-center" style="margin-bottom:0">${Message}</p></div>`);


              let rgbd = rgbDistance / Math.sqrt(3 * 255 * 255) * 100;
               $('#ccc-LiveRatioValue span').text(contrastRatio.toFixed(1) + " / 21.0");
              $('#ccc-LiveRGBDistance span').text(rgbd.toFixed(0) + " / 100");
              $('#ccc-LiveSaturationDifference span').text(saturationDiff.toFixed(0) + " / 100");
              $('#ccc-LiveHueDifference span').text(hueDiff.toFixed(0) + " / 100");
              $('#ccc-LiveLightnessDifference span').text(lightnessDiff.toFixed(0) + " / 100");

    }

    function synchronizeColorInputs() {
        $foregroundColorPicker.val($foregroundHexInput.val());
        $backgroundColorPicker.val($backgroundHexInput.val());
        updatePreviewAndContrast();
    }

    function synchronizeHexInputs() {
        $foregroundHexInput.val($foregroundColorPicker.val().toUpperCase());
        $backgroundHexInput.val($backgroundColorPicker.val().toUpperCase());
        updatePreviewAndContrast();
    }

    function luminance(r, g, b) {
        const a = [r, g, b].map(v => {
            v /= 255;
            return v <= 0.03928 ? v / 12.92 : Math.pow((v + 0.055) / 1.055, 2.4);
        });
        return a[0] * 0.2126 + a[1] * 0.7152 + a[2] * 0.0722;
    }

    function contrast(rgb1, rgb2) {
        const lum1 = luminance(rgb1[0], rgb1[1], rgb1[2]);
        const lum2 = luminance(rgb2[0], rgb2[1], rgb2[2]);
        return (Math.max(lum1, lum2) + 0.05) / (Math.min(lum1, lum2) + 0.05);
    }

    function ColorSetterCheck($element, isValid) {
        $element.toggleClass('Success-Result', isValid).toggleClass('Fail-Result', !isValid);
    }

    $foregroundColorPicker.add($backgroundColorPicker).on('input', synchronizeHexInputs);
    $foregroundHexInput.add($backgroundHexInput).on('input', synchronizeColorInputs);

    $('#ccc-foreground').on('input', function () {
        $('#ccc-foregroundHex').val($(this).val().toUpperCase());
    });

    $('#ccc-foregroundHex').on('input', function () {
        const hexPattern = /^#[0-9A-F]{6}$/i;
        if (hexPattern.test($(this).val())) {
            $('#ccc-foreground').val($(this).val().toUpperCase());
        }
    });

    $("#font-selector").on('change', function () {
       const selectedFont = $(this).val().replace(/\+/g, ' ');
        $("#ccc-preview .preview-text").css("font-family" , selectedFont) ;
    });

    $("#Swap-Colors").on('click', function () {
       let A = $('#ccc-foregroundHex').val();
       let B = $('#ccc-backgroundHex').val();
       $('#ccc-foreground').val(B);
       $('#ccc-background').val(A);
       $('#ccc-foregroundHex').val(B);
       $('#ccc-backgroundHex').val(A);
       synchronizeHexInputs();
    });

    function Show_Saved_Colors(){
        let HTML = "";
        let SavedColors = LS_Get("Contrast-Color-Checker");
        if (Object.keys(SavedColors).length === 0) {
              LS_Store("Contrast-Color-Checker" , JSON.stringify([]));
         }
         else{
           for (var i = 0; i < SavedColors.length; i++) {
                let item = SavedColors[i];
               HTML += "<button class='SaveColor' data-bcg='" + item.bc + "' data-tc='" + item.tc + "' data-tf='" + item.f +"' style='background-color: "+item.bc+";color: "+item.tc+";font-family: "+item.f+";border: 2px solid "+item.tc+";'>Aa</button>";
            }
         }
         $("#SavedColors").empty().append(HTML);
    }

    $("#Save-Colors").on('click', function () {
       let A = $('#ccc-foregroundHex').val();
       let B = $('#ccc-backgroundHex').val();
       let C = $("#font-selector").val();

       let SavedColors = LS_Get("Contrast-Color-Checker");
         if (Object.keys(SavedColors).length === 0) {
              LS_Store("Contrast-Color-Checker" , JSON.stringify([{ "tc": A , "bc" : B, "f" : C}]));
         }
         else if(Object.keys(SavedColors).length >= 9) {
            alert("You can save Max 10 records.");
         }
         else {
                var newItem = { "tc": A, "bc": B, "f": C};
                LS_Add_New_Obj(newItem , "Contrast-Color-Checker");
         }

         Show_Saved_Colors();
    });

    $("#Clear-Colors").on('click', function () {
       LS_Delete("Contrast-Color-Checker");
       Show_Saved_Colors();
    });
    
    $("body .details_wrap").on("click", ".SaveColor", function () {

        let A = $(this).attr("data-bcg");
        let B = $(this).attr("data-tc");
        let C = $(this).attr("data-tf");

        $foregroundColorPicker.val(B);
        $backgroundColorPicker.val(A);
        $foregroundHexInput.val(B.toUpperCase());
        $backgroundHexInput.val(A.toUpperCase());
        updatePreviewAndContrast();
        
    });

    updatePreviewAndContrast();
    Show_Saved_Colors();

});