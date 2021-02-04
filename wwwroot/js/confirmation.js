/*File to check to see if values are valid and if so, send an alert to user saying that their response was recorded*/
$("#submitButton").click(function () {
    /*Pull values of form into variables*/
    var category = $("#Category").val();
    var title = $("#Title").val();
    var year = $("#Year").val();
    var director = $("#Director").val();
    var rating = $("#Rating").val();
    var edited = $("input:radio[name='Edited']:checked").val();
    var lentTo = $("#LentTo").val();
    var notes = $("#Notes").val();
    /*Checks required fields are not empty, that note length is not longer than 25, and that year is valid*/
    if ((category != "") && (title != "") && (year != "") && (director != "") && (rating != "") && (notes.length < 25) && ((year >= 1888) && (year <= 9999))) {
        alert("Congratulations! Your response was successfully submitted:"
            + "\n\nCategory: " + category
            + "\nTitle: " + title
            + "\nYear: " + year
            + "\nDirector: " + director
            + "\nRating: " + rating
            + "\nEdited: " + edited
            + "\nLent To: " + lentTo            
            + "\nNotes: " + notes);
    }
});