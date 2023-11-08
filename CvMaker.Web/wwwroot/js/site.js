// Search by id in CvList
$(document).ready(function () {
    $('#searchName').on('input', function () {
        var searchText = $(this).val().toLowerCase();
        var searchTerms = searchText.split(' '); // Split input into first name and last name
        var firstName = searchTerms[0];
        var lastName = searchTerms[1];

        $('tbody tr').each(function () {
            var firstNameColumnText = $(this).find('td:eq(1)').text().toLowerCase(); // Second column is the first name
            var lastNameColumnText = $(this).find('td:eq(2)').text().toLowerCase(); // Third column is the last name

            var firstNameMatch = firstNameColumnText.includes(firstName);
            var lastNameMatch = lastName ? lastNameColumnText.includes(lastName) : true; // Check last name only if provided

            if (firstNameMatch && lastNameMatch) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });
});