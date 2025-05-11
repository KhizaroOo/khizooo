
// Default Colors (Best for 100/100 score)
var defaultColors = {
    background: "#F2F4F0",         // Warm light gray-beige (soft, not pure white)
    heading: "#000000",            // Espresso black (elegant and deep)
    subheading: "#3E3E3E",         // Warm gray — clear but soft
    paragraph: "#525252",          // Medium-muted gray (excellent readability)
    link: "#0E0ADB",               // Muted teal-blue (modern and trustworthy)
    btnBackground: "#275936",      // Deep burnt sienna (rich, earthy tone)
    btnText: "#F2F4F0"             // White text — contrast ratio: 8.5:1 (AAA)
};



// Creating Color Fields
var fields = [
    { label: 'Background Color', id: 'background' },
    { label: 'Heading Color', id: 'heading' },
    { label: 'Subheading Color', id: 'subheading' },
    { label: 'Paragraph Color', id: 'paragraph' },
    { label: 'Link Color', id: 'link' },
    { label: 'Button Background', id: 'btnBackground' },
    { label: 'Button Text Color', id: 'btnText' }
];

// Build Inputs
var colorInputs = document.getElementById('colorInputs');
fields.forEach(f => {
    colorInputs.innerHTML += `
  <div class="form-group mb-3">
    <label for="${f.id}" class="font-weight-bold mb-2">${f.label}</label>
    <div class="d-flex align-items-center">
      <input type="color" id="${f.id}" class="form-control form-control-sm mr-2 col-6" style="height:42px;">
      <input type="text" id="${f.id}Hex" class="form-control form-control-sm mr-2 col-3" style="height:42px;" readonly>
      <button type="button" class="btn btn-sm btn-primary col-2" style="height:42px;" onclick="copyHex('${f.id}')">Copy</button>
    </div>
  </div>
`;

});

// Copy HEX code
function copyHex(id) {
    var hexInput = document.getElementById(id + 'Hex');
    hexInput.select();
    document.execCommand('copy');
    alert('Copied: ' + hexInput.value);
}

// Reset All Colors
function resetColors() {
    fields.forEach(f => {
        document.getElementById(f.id).value = defaultColors[f.id];
    });
    updatePreview();
    updateScore();
}

// Export JSON Report
function exportJSON() {
    var colors = {};
    fields.forEach(f => {
        colors[f.label] = document.getElementById(f.id).value;
    });
    var score = document.getElementById('finalScore').innerText;
    var json = {
        colors: colors,
        finalScore: score
    };
    var blob = new Blob([JSON.stringify(json, null, 2)], { type: "application/json" });
    var link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'color-contrast-report.json';
    link.click();
}

// Download Preview Box as Image
function downloadImage() {
    html2canvas(document.getElementById('ResultCanvas')).then(function (canvas) {
        var link = document.createElement('a');
        link.download = 'preview.png';
        link.href = canvas.toDataURL();
        link.click();
    });
}

// HEX to RGB
function hexToRgb(hex) {
    var bigint = parseInt(hex.substring(1), 16);
    var r = (bigint >> 16) & 255;
    var g = (bigint >> 8) & 255;
    var b = bigint & 255;
    return [r, g, b];
}

// Calculate luminance
function luminance(r, g, b) {
    var a = [r, g, b].map(v => {
        v /= 255;
        return v <= 0.03928 ? v / 12.92 : Math.pow((v + 0.055) / 1.055, 2.4);
    });
    return a[0] * 0.2126 + a[1] * 0.7152 + a[2] * 0.0722;
}

// Contrast ratio calculation
function contrast(rgb1, rgb2) {
    var lum1 = luminance(rgb1[0], rgb1[1], rgb1[2]);
    var lum2 = luminance(rgb2[0], rgb2[1], rgb2[2]);
    return (Math.max(lum1, lum2) + 0.05) / (Math.min(lum1, lum2) + 0.05);
}

// Update Preview Box live
function updatePreview() {
    fields.forEach(f => {
        let color = document.getElementById(f.id).value;
        document.getElementById(f.id + 'Hex').value = color.toUpperCase();
    });

    document.getElementById('previewBox').style.backgroundColor = document.getElementById('background').value;
    document.getElementById('previewHeading').style.color = document.getElementById('heading').value;
    document.getElementById('previewSubheading').style.color = document.getElementById('subheading').value;
    document.getElementById('previewParagraph').style.color = document.getElementById('paragraph').value;
    document.getElementById('previewLink').style.color = document.getElementById('link').value;

    document.getElementById('previewBtn1').style.backgroundColor = document.getElementById('btnBackground').value;
    document.getElementById('previewBtn1').style.color = document.getElementById('btnText').value;
    document.getElementById('previewBtn2').style.backgroundColor = document.getElementById('btnBackground').value;
    document.getElementById('previewBtn2').style.color = document.getElementById('btnText').value;

    //updatePalette();
}

// Update Score Calculation
function updateScore() {
    var combos = [
        { label: 'Background + Heading', color1: 'heading', color2: 'background', points: 20 },
        { label: 'Background + Subheading', color1: 'subheading', color2: 'background', points: 20 },
        { label: 'Background + Paragraph', color1: 'paragraph', color2: 'background', points: 20 },
        { label: 'Background + Link', color1: 'link', color2: 'background', points: 20 },
        { label: 'Button Background + Button Text', color1: 'btnText', color2: 'btnBackground', points: 5 },
        { label: 'Background + Button Background', color1: 'btnBackground', color2: 'background', points: 15 }
    ];

    let totalScore = 0;
    let scoreDetails = '';

    combos.forEach(pair => {
        var c1 = hexToRgb(document.getElementById(pair.color1).value);
        var c2 = hexToRgb(document.getElementById(pair.color2).value);
        var ratio = contrast(c1, c2);
        let achieved = 0;

        if (ratio >= 7) achieved = pair.points;
        else if (ratio >= 4.5) achieved = Math.round(pair.points * 0.8);
        else if (ratio >= 3) achieved = Math.round(pair.points * 0.6);
        else achieved = Math.round(pair.points * 0.3);

        totalScore += achieved;
        var status = ratio >= 4.5 ? '<span class="badge badge-success float-right mr-2 p-2">PASS</span>' : '<span class="badge badge-danger mr-2 p-2">FAIL</span>';
        var suggestion = ratio < 4.5 ? '<div class="suggestion-text">Improve: Darken background or lighten text</div>' : '';
        var achieve = `<span class="badge badge-primary badge-pill p-2">${achieved <= 9 ? "0" + achieved : achieved}/${pair.points <= 9 ? "0" + pair.points : pair.points}</span>`;

        scoreDetails += `
      <li class="list-group-item d-block p-3">
        <div class="d-flex justify-content-between align-items-center">
          <span style="font-size:10px; font-weight:600;">${pair.label}</span>
          <div class="d-flex">
            ${status}
            ${achieve}
          </div>
        </div>
        ${suggestion}
      </li>`;
    });

    // Update score section
    document.getElementById('scoreDetails').innerHTML = scoreDetails;
    document.getElementById('finalScore').innerText = `${totalScore}/100`;

    // Color logic for score circle
    var scoreCircle = document.getElementById('scoreCircle');
    var scoreMessage = document.getElementById('scoreMessage');
    let bgColor = '';
    let message = '';

    if (totalScore >= 90) {
        bgColor = '#28a745'; // Green
        message = 'Excellent contrast! Accessibility approved.';
    } else if (totalScore >= 70) {
        bgColor = '#ffc107'; // Yellow
        message = 'Good, but a few tweaks can improve it further.';
    } else {
        bgColor = '#dc3545'; // Red
        message = 'Poor contrast. Needs significant improvement.';
    }

    scoreCircle.style.backgroundColor = bgColor;
    scoreMessage.style.color = bgColor;
    scoreMessage.innerText = message;
}

// Build Color Palette Preview
function updatePalette() {
    var paletteGrid = document.getElementById('paletteGrid');
    paletteGrid.innerHTML = '';

    fields.forEach(f => {
        paletteGrid.innerHTML += `
      <div class="col-6 col-md-4">
        <div class="palette-card">
          <div class="palette-square" style="background:${document.getElementById(f.id).value};"></div>
          <div class="palette-hex">${document.getElementById(f.id).value.toUpperCase()}</div>
        </div>
      </div>
    `;
    });
}

// Events - Live updates
fields.forEach(f => {
    document.getElementById(f.id).addEventListener('input', () => {
        updatePreview();
        updateScore();
    });
});

// Initialize Default
resetColors();