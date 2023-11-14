const goBack = () => window.history.back();



$(() => {

    //EVENTLISTENERS
    $(".clickable-row").on('click', function () {
        console.log($(this).data("href"))
        window.location = `City/${$(this).data("href")}`;
    });

    $(".back").on('click', goBack);
})