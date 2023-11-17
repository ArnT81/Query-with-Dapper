const clearContent = () => {
    $('.content').empty();
    $('.description').empty();

}


const getData = async (string) => {
    const response = await $.ajax({
        url: string,
        success: result => result
    })
    const data = await response;

    return data;
};


const handleDescription = (assignment) => {
    return {
        0: "YEHHO",
        1: `Present a list of strongly typed city data for all cities in a span between two population numbers. Use a view file (cshtml) for the presentation and use a table for the data.`,
        3: `Limit the number of posts read.`,
        2: `Read all cities by country code.`,
        4: `Read all European countries ordered by life expectancy, high to low.`,
        5: `Read all cities in a country.`,
        6: `Read all cities in a continent with a life expectancy above a certain age.`,
    }[assignment] || notFound();
};


const handleResponse = (assignment) => {
    return {
        0: () => clearContent(),
        1: () => getData('Home/Basic'),
        2: () => getData('Home/OptionalAssignment1'),
        3: () => getData('Home/OptionalAssignment2'),
        4: () => getData('Home/OptionalAssignment3'),
        5: () => getData('Home/OptionalAssignment4'),
        6: () => getData('Home/OptionalAssignment5'),
    }[assignment]?.(assignment) || notFound();
};


const renderData = (data) => {
    console.log('get Assignment text', data)
    data?.forEach((item) => {
        $('.content').append(`<div> ${item.name}</div>`)
    })
};


const renderDescription = (description) => {
    $('.description').html(`<div><p>${description}</p></div>`)
};



$(() => {
    console.log('script: wwwroot => js => home.js')

    //EVENTLISTENERS
    $('#select_category').on('change', async function () {
        const data = await handleResponse($(this).val());
        const description = await handleDescription($(this).val());

        clearContent()
        renderData(data)
        renderDescription(description)
    })
})