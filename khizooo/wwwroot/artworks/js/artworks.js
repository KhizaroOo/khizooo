
var SelectedTitle = "";
var SelectedSlug = "";
var SelectedImage = "";


function openArtModal(e) {

    let ArtTitle = $(e).find("h6").text();
    let ArtImage = $(e).find("img").attr("src");
    SelectedTitle = ArtTitle;
    SelectedImage = ArtImage;
    $("#ArtTitle").text(ArtTitle);
    $("#ArtImg").attr("src", ArtImage);
    $("#ArtImg").attr("data-title", ArtTitle);
    $("#ArtModal").modal("show");
}

function downloadArt() {
 
    const link = document.createElement('a');
    link.href = SelectedImage;
    link.download = SelectedTitle + '.jpg';

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}