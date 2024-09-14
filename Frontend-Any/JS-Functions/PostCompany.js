
async function PostCompany(e){
    e.preventDefault();
    let companyID = document.getElementById("id").value;
    let companyName = document.getElementById("cName").value;
    let companyLogoURL = document.getElementById("logoURL").value;
    let companyTOS = document.getElementById("tos").value;

    console.log(companyLogoURL);
    

    try{
        await fetch("https://localhost:7020/api/CompanyDetails/",{
            method: "Post",
            headers : {"Content-Type" : "application/json"},
            body: JSON.stringify({companyID, companyName, companyLogoURL, companyTOS})
        }).then(res => res.json())
        .then(res => console.log(res))
    }catch(e){
        console.log(e)
    }
}