$(document).ready(function () {

    const $gradientType = $('.GradientType select');
    const $direction = $('.direction');
    const $position = $('.position');
    const $blendMode = $('.blendMode');
    const $colorInputs = $('.colors input');
    const $blendColorInputs = $('.blendMode input');
    const $gradientColorBox = $('.gradientColorBox');
    const $textarea = $('textarea');
    const $refreshBtn = $('.refreshBtn');
    const $copyBtn = $('.copyBtn');

    $position.hide();

    function generateGradient(isRandom) {
        const gradientType = $gradientType.val();
        const direction = $('.direction select').val();
        const position = $('.position select').val();
        const selectedBlendMode = $('.blendMode select').val();
        const color1 = $colorInputs.eq(0).val();
        const color2 = $colorInputs.eq(1).val();
        const color3 = $blendColorInputs.eq(0).val();

        let gradient_css = '';
        let blend_css = `background-blend-mode: ${selectedBlendMode};`;

        if (gradientType === 'linear') {
            gradient_css = `linear-gradient(${direction}, ${color1}, ${color2})`;
        } else {
            gradient_css = `radial-gradient(circle at ${position}, ${color1}, ${color2})`;
        }

        let CSS = `background: ${gradient_css}, ${color3};\n${blend_css}`;
        $gradientColorBox.css({
            'background': `${gradient_css}, ${color3}`,
            'background-blend-mode': selectedBlendMode
        });

        $textarea.val(CSS);
    }


    $gradientType.on('change', function () {
        if ($(this).val() === 'linear') {
            $direction.show();
            $position.hide();
        } else {
            $direction.hide();
            $position.show();
        }
        generateGradient(false);
    });

    $direction.on('change', function () {
        generateGradient(false);
    });

    $position.on('change', function () {
        generateGradient(false);
    });

    $blendMode.on('change', function () {
        generateGradient(false);
    });

    $blendColorInputs.on('input', function () {
        generateGradient(false);
    });

    $colorInputs.on('input', function () {
        generateGradient(false);
    });

    $refreshBtn.on('click', function () {
        $colorInputs.eq(0).val(getRandomColor());
        $colorInputs.eq(1).val(getRandomColor());
        generateGradient(false);
    });

    $copyBtn.on('click', function () {
        navigator.clipboard.writeText($textarea.val());
        $copyBtn.text('Code Copied');
        setTimeout(function () {
            $copyBtn.text('Copy Code');
        }, 2000);
    });

    function getRandomColor() {
        const randomHexColor = Math.floor(Math.random() * 0xffffff).toString(16);
        return `#${randomHexColor.padStart(6, '0')}`;
    }

    generateGradient(false);

});
