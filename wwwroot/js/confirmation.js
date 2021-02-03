$("#submitButton").click(function () {
    var category = $("#Category").val();
    var title = $("#Title").val();
    var year = $("#Year").val();
    var director = $("#Director").val();
    var rating = $("#Rating").val();
    var edited = $("#Edited").val();
    var lentTo = $("#LentTo").val();
    var notes = $("#Notes").val();

    if ((category != "") && (title != "") && (year != "") && (director != "") && (rating != "") && (notes.length < 25) && ((year >= 1888) && (year <= 9999))) {
        alert("Congratualtions, your response was successfully submitted:"
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