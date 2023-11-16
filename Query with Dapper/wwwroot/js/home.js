const clearContent = () => $('.content').empty();


const getData = async (string) => {
    const response = await $.ajax({
        url: string,
        success: result => result
    })
    const data = await response;

    return data;
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
    clearContent()

    console.log('get Assignment text', data)
    data?.forEach((item) => {
        $('.content').append(`<div> ${item.name}</div>`)
    })
};


$(() => {
    console.log('script: wwwroot => js => home.js')

    //EVENTLISTENERS
    $('#select_category').on('change', async function () {
        const data = await handleResponse($(this).val());
        renderData(data)
    })
})