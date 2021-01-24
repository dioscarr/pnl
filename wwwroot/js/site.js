
    $(document).ready(function () {
        
        $('#TaxesRecords').DataTable({"pagingType": "full_numbers" });
    });



$(document).ready(function () {

    let btnPrvTaxes = document.getElementById("btn-prv-taxes")
    if (btnPrvTaxes != null) {
        btnPrvTaxes.addEventListener("click", function () {
            let prvTaxesList = document.getElementsByClassName("prv-taxes-list");

            if ($(prvTaxesList).is(":hidden")) {
                for (let index = 0; index < prvTaxesList.length; index++) {
                    let element = prvTaxesList[index];
                    $(element).show();
                }
                let bodyDash = document.getElementById("bodyid");
                bodyDash.style.overflowY = "scroll"
                console.log(bodyDash.style.getPropertyValue("overflowY"));
            }
            else {
                for (let index = 0; index < prvTaxesList.length; index++) {
                    let element = prvTaxesList[index];
                    $(element).hide();
                }
                if (document.getElementById("bodyid") !==null) {
                let bodyDash = document.getElementById("bodyid");
                bodyDash.style.overflowY = "hidden"
                console.log(bodyDash.style.getPropertyValue("overflowY"));
                }
            }



        })
    }
});
var Goto = async (url, id, status) => {
    url = `${url}?id=${id}&status=${status}`;
    window.location.href = url;   
}
var GotoPath = async (url) => {
   
    window.location.href = url;
}