////class OrganizationEditModel {
////    Name = "";
////    PhoneNumber = "";
////    Email = "";
////    UserName = "";
////    Address1 = "";
////    Address2 = "";
////    CountryId = "";
////    StateId = "";
////    CityId = "";
////    Status = "";
////    Description = "";

////    constructor() {

////    }

////    populateModel(data) {
////        this.Name = data.Name;
////        this.PhoneNumber = data.PhoneNumber;
////        this.Email = data.Email;
////        this.UserName = data.UserName;
////        this.Address1 = data.Address1;
////        this.Address2 = data.Address2;
////        this.CountryId = data.CountryId;
////        this.StateId = data.StateId;
////        this.CityId = data.CityId;
////        this.Status = data.Status;
////        this.Description = data.Description;

////    }

////    populateFields() {
////        $("#Name").val(this.Name);
////        $("#PhoneNumber").val(this.PhoneNumber);
////        $("#Email").val(this.Email);
////        $("#UserName").val(this.UserName);
////        $("#Address1").val(this.Address1);
////        $("#Address2").val(this.Address2);
////        $("#Countries").val(this.CountryId);
////        $("#States").val(this.StateId);
////        $("#Cities").val(this.CityId);
////        $("[name='Status']" + "[value=" + this.Status + "]").prop('checked', true);
////        $("#Description").val(this.Description);
////    }

////    populateFromForm() {
////        this.Name = $("#Name").val();
////        this.PhoneNumber = $("#PhoneNumber").val();
////        this.Email = $("#Email").val();
////        this.UserName = $("#UserName").val();
////        this.Address1 = $("#Address1").val();
////        this.Address2 = $("#Address2").val();
////        this.CountryId = $("#Countries").val();
////        this.StateId = $("#States").val();
////        this.CityId = $("#Cities").val();
////        this.Status = $("[name='Status']:checked").val();
////        this.Description = $("#Description").val();
////    }
////}