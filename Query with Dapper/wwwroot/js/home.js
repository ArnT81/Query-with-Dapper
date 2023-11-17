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
    console.log(data)
    return data;
};


const handleDescription = (assignment) => {
    return {
        0: "",
        1: `Present a list of strongly typed city data for all cities in a span between two population numbers. Use a view file (cshtml) for the presentation and use a table for the data.`,
        3: `Limit the number of posts read.`,
        2: `Read all cities by country code.`,
        4: `Read all European countries ordered by life expectancy, high to low.`,
        5: `Read all cities in a country.`,
        6: `Read all cities in a continent with a life expectancy above a certain age.`,
    }[assignment];
};


const handleResponse = (assignment) => {
    const min = $('#min').val() || 100
    const max = $('#max').val() || 20000
    const limit = $('#limit').val() || 10
    const countrycode = $('#countrycode').val() || 'SWE'
    const countryName = $('#countryName').val() || 'sweden'
    const continent = $('#continent').val() || 'asia'
    const age = $('#age').val() || 80

    return {
        0: () => clearContent(),
        1: () => getData(`Home/Basic?min=${min}&max=${max}`),
        2: () => getData(`Home/OptionalAssignment1?limit=${limit}`),
        3: () => getData(`Home/OptionalAssignment2?countrycode=${countrycode}`),
        4: () => getData('Home/OptionalAssignment3'),
        5: () => getData(`Home/OptionalAssignment4?countryName=${countryName}`),
        6: () => getData(`Home/OptionalAssignment5?continent=${continent}&age=${age}`),
    }[assignment]?.(assignment);
};


const renderData = (data) => {
    $('.content').append(`<tr><th scope="col">#</th>  <th scope="col">Name</th>  <th scope="col">Population</th>  <th scope="col">Life expectancy</th> </tr>`)
    data?.forEach((item, i) => {
        console.log(item)
        $('.content').append(`<tr><th scope= "row">${i + 1}</th>   <td>${item.name}</td> <td>${item.population}</td> <td>${item.lifeExpectancy}</td></tr>`)
    })
};


const renderDescription = (description) => $('.description').html(`<div><p>${description}</p></div>`);
//RENDER CONDITIONAL INPUTS
const renderBasicAssignmentInput = () => $('#input_user').html(`<input type="number" placeholder="min" id="min"/> <input type="number" placeholder="max" id="max"/>`)
const renderFirstOptionalAssignmentInput = () => $('#input_user').html(`<input type="number" placeholder="limit results" id="limit"/>`)
const renderSecondOptionalAssignmentInput = () => $('#input_user').html(`<input type="text" placeholder="countrycode" id="countrycode"/>`)
const renderThirdOptionalAssignmentInput = () => $('#input_user').empty();
const renderFourthOptionalAssignmentInput = () => $('#input_user').html(`<input type="text" placeholder="Country Name" id="countryName"/>`)
const renderFifthOptionalAssignmentInput = () => $('#input_user').html(`<input type="text" placeholder="continent" id="continent"/> <input type="number" placeholder="life expectancy (years)" id="age"/>`)


const renderConditionalUserInput = (assignment) => {
    return {
        0: clearContent(),
        1: () => renderBasicAssignmentInput(),
        2: () => renderFirstOptionalAssignmentInput(),
        3: () => renderSecondOptionalAssignmentInput(),
        4: () => renderThirdOptionalAssignmentInput(),
        5: () => renderFourthOptionalAssignmentInput(),
        6: () => renderFifthOptionalAssignmentInput(),
    }[assignment]?.(assignment);
}


//DOMCONTENT LOADED
$(() => {
    console.log('script: wwwroot => js => home.js')

    //EVENTLISTENERS
    $('#select_category').on('change', async function () {
        renderConditionalUserInput($(this).val())
        const data = await handleResponse($(this).val());
        const description = await handleDescription($(this).val());

        clearContent()
        renderData(data)
        renderDescription(description)
    })

    $('#submit').on('click', async () => {
        const data = await handleResponse($('#select_category').val());
        const description = await handleDescription($('#select_category').val());

        clearContent()
        renderData(data)
        renderDescription(description)
    })
})