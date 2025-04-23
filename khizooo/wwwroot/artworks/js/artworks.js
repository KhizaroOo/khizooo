
function openArtModal(e) {

    let ArtTitle = $(e).find("h6").text();
    let ArtImage = $(e).find("img").attr("src");
    $("#ArtTitle").text(ArtTitle);
    $("#ArtImg").attr("src", ArtImage);
    $("#ArtImg").attr("data-title", ArtTitle);
    $("#ArtModal").modal("show");
}

function downloadArt() {
    const img = document.getElementById('ArtImg');
    const artUrl = img.src;
    const artTitle = img.attr("data-title");

    const link = document.createElement('a');
    link.href = imageUrl;

    // Set download filename (optional: dynamic from alt text)
    const fileName = img.alt ? img.alt.replace(/\s+/g, '-') + '.jpg' : artTitle + '.jpg';
    link.download = fileName;

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}