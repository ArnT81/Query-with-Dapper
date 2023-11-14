const goBack = () => window.history.back();



$(() => {

    //EVENTLISTENERS
    $(".clickable-row").on('click', function () {
        window.location = `City/${$(this).data("href")}`;
    });

    $(".back").on('click', goBack);
})