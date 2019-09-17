
validateTextField("CheckinDate", "Please enter valid CheckinDate.");
validateTextField("CheckoutDate", "Please enter valid CheckoutDate.");

validateTextField("NoOfAdult", "Please enter valid NoOfAdult.");
validateTextField("NoOfChild", "Please enter valid NoOfChild.");

validateTextField("FirstName", "Please enter valid FirstName.");
validateTextField("LastName", "Please enter valid LastName.");

validateTextField("Address", "Please enter valid Address.");
validateTextField("Email", "Please enter valid Email.");

validateTextField("Remarks", "Please enter valid Remarks.");
validateTextField("Dob", "Please enter valid Dob.");

validateTextField("Nationality", "Please enter valid Nationality.");
validateTextField("ContactNumber", "Please enter valid ContactNumber.");

validateDropDownField("BillingType", "Please enter valid BillingType.");
validateTextField("AdvanceAmount", "Please enter valid AdvanceAmount.");

var checkinDate = "";
var checkoutDate = "";
var noOfAdult = 0; var noOfChild = 0;
var firstName = ""; var lastName = ""; var address = ""; var contactNumber = "";
var nid = ""; var passport = ""; var email = ""; var remarks = "";
var dob = ""; var nationality = ""; var billingType = "";
var advanceAmount = ""; var creditCardNo = "";
var roomTypes = "";

var MESSAGE_SHOW_INTERVAL = 10000;

function showMessage(msg, type) {
    if (type == "s") {
        $(".customMessage").append('<div class="alert alert-success"><a class="close" data-dismiss="alert">×</a><strong>Success!</strong> ' + msg + '.</div>');
    }
    else if (type == "e") {
        $(".customMessage").append('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><strong>Error!</strong> ' + msg + '.</div>');
    }
    $('html, body').animate({
        scrollTop: $(".customMessage").offset().top
    }, 2000);

    //scrollToElement(".customMessage");
    setTimeout(function () {
        $(".customMessage").html("");
    }, MESSAGE_SHOW_INTERVAL);
}

function ReservationVm() {

    this.CheckinDate = "";
    this.CheckoutDate = "";
    this.NoOfAdult = 0;
    this.NoOfChild = 0;
    this.FirstName = "";
    this.LastName = "";
    this.Address = "";
    this.ContactNumber = "";
    this.Nid = "";
    this.Passport = "";
    this.Email = "";
    this.Remarks = "";
    this.Dob = "";
    this.Nationality = "";
    this.BillingType = "";
    this.AdvanceAmount = 0;
    this.CreditCardNo = "";
    this.RoomTypes = "";
    this.RoomIds = [];

}

function ValidateReservationForm() {
    var isTrue = true;
    checkinDate = $("#CheckinDate").val();
    if (checkinDate.length <= 0) {
        showErrorMessageBelowCtrl("CheckinDate", "", false);
        showErrorMessageBelowCtrl("CheckinDate", "Please enter valid Checkin Date", true);
        isTrue = false;
    }
    checkoutDate = $("#CheckoutDate").val();
    if (checkoutDate.length <= 0) {
        showErrorMessageBelowCtrl("CheckoutDate", "", false);
        showErrorMessageBelowCtrl("CheckoutDate", "Please enter valid Checkout Date", true);
        isTrue = false;
    }

    noOfAdult = $("#NoOfAdult").val();
    if (noOfAdult <= 0) {
        showErrorMessageBelowCtrl("NoOfAdult", "", false);
        showErrorMessageBelowCtrl("NoOfAdult", "Please enter valid No Of Adult", true);
        isTrue = false;
    }
    noOfChild = $("#NoOfChild").val();
    if (noOfChild <= 0) {
        showErrorMessageBelowCtrl("NoOfChild", "", false);
        showErrorMessageBelowCtrl("NoOfChild", "Please enter valid No Of Child", true);
        isTrue = false;
    }

    firstName = $("#FirstName").val();
    if (firstName.length <= 0) {
        showErrorMessageBelowCtrl("FirstName", "", false);
        showErrorMessageBelowCtrl("FirstName", "Please enter valid FirstName", true);
        isTrue = false;
    }
    lastName = $("#LastName").val();
    if (lastName.length <= 0) {
        showErrorMessageBelowCtrl("LastName", "", false);
        showErrorMessageBelowCtrl("LastName", "Please enter valid LastName", true);
        isTrue = false;
    }
    address = $("#Address").val();
    if (address.length <= 0) {
        showErrorMessageBelowCtrl("Address", "", false);
        showErrorMessageBelowCtrl("Address", "Please enter valid Address", true);
        isTrue = false;
    }
    contactNumber = $("#ContactNumber").val();
    if (contactNumber.length <= 0) {
        showErrorMessageBelowCtrl("ContactNumber", "", false);
        showErrorMessageBelowCtrl("ContactNumber", "Please enter valid Contact Number", true);
        isTrue = false;
    }

    nid = $("#Nid").val();
    passport = $("#Passport").val();
    roomTypes = $("#RoomTypes").val();
    email = $("#Email").val();
    if (email.length <= 0) {
        showErrorMessageBelowCtrl("Email", "", false);
        showErrorMessageBelowCtrl("Email", "Please enter valid Email", true);
        isTrue = false;
    }
    remarks = $("#Remarks").val();

    dob = $("#Dob").val();
    if (dob.length <= 0) {
        showErrorMessageBelowCtrl("Dob", "", false);
        showErrorMessageBelowCtrl("Dob", "Please enter valid Dob", true);
        isTrue = false;
    }
    nationality = $("#Nationality").val();
    if (nationality.length <= 0) {
        showErrorMessageBelowCtrl("Nationality", "", false);
        showErrorMessageBelowCtrl("Nationality", "Please enter valid Nationality", true);
        isTrue = false;
    }

    billingType = $("#BillingType").val();
    if (billingType.length <= 0) {
        showErrorMessageBelowCtrl("BillingType", "", false);
        showErrorMessageBelowCtrl("BillingType", "Please enter valid BillingType", true);
        isTrue = false;
    }
    advanceAmount = $("#AdvanceAmount").val();
    if (advanceAmount.length <= 0) {
        showErrorMessageBelowCtrl("AdvanceAmount", "", false);
        showErrorMessageBelowCtrl("AdvanceAmount", "Please enter valid AdvanceAmount", true);
        isTrue = false;
    }

    creditCardNo = $("#CreditCardNo").val();
    if (isTrue == false) {
        return false;
    } else {
        return true;
    }

}


$(document).on("click", "#reservationBtn", function () {

    if (ValidateReservationForm()) {

        var hotelResObj = new ReservationVm();
        var roomIds = [];
        $(".reserveroom").each(function () {
            if ($(this).is(':checked')) {
                var ids = $(this).attr("data-id");
                roomIds.push(ids);
            }
        });
        hotelResObj.CheckinDate = checkinDate;
        hotelResObj.CheckoutDate = checkoutDate;
        hotelResObj.NoOfAdult = noOfAdult;
        hotelResObj.NoOfChild = noOfChild;
        hotelResObj.FirstName = firstName;
        hotelResObj.LastName = lastName;
        hotelResObj.Address = address;
        hotelResObj.ContactNumber = contactNumber;
        hotelResObj.Nid = nid;
        hotelResObj.Passport = passport;
        hotelResObj.Email = email;
        hotelResObj.Remarks = remarks;
        hotelResObj.Dob = dob;
        hotelResObj.Nationality = nationality;
        hotelResObj.BillingType = billingType;
        hotelResObj.AdvanceAmount = advanceAmount;
        hotelResObj.CreditCardNo = creditCardNo;
        hotelResObj.RoomTypes = roomTypes;
        hotelResObj.RoomIds = roomIds;

        console.log(hotelResObj);
        var hotelReservationObj = JSON.stringify(hotelResObj);

        $.ajax({
            url: "/HotelReservation/SaveRoomReservation",
            type: "POST",
            data: { hotelReservationObj: hotelReservationObj },
            beforeSend: function () {
                $.blockUI({
                    timeout: 0,
                    message: '<h1><img src="/Content/Image/ajax-loader.gif" /> Processing...</h1>'
                });
            },
            success: function (data) {
                $.unblockUI();

            },
            complete: function () {
                $.unblockUI();
            },
            error: function (data) {
                $.unblockUI();
                bootbox.alert("Slow Internet Connection").css('margin-top', (($(window).height() / 4)));
            }
        });
    }
});

$(document).on("click", "#bookingBtn", function () {
    console.log("hello");
    if (ValidateReservationForm()) {

        var hotelResObj = new ReservationVm();
        var roomIds = [];
        $(".reserveroom").each(function () {
            console.log($(this).attr("data-id"));
            if ($(this).is(':checked')) {
                var ids = $(this).attr("data-id");
                roomIds.push(ids);
            }
        });
        hotelResObj.CheckinDate = checkinDate;
        hotelResObj.CheckoutDate = checkoutDate;
        hotelResObj.NoOfAdult = noOfAdult;
        hotelResObj.NoOfChild = noOfChild;
        hotelResObj.FirstName = firstName;
        hotelResObj.LastName = lastName;
        hotelResObj.Address = address;
        hotelResObj.ContactNumber = contactNumber;
        hotelResObj.Nid = nid;
        hotelResObj.Passport = passport;
        hotelResObj.Email = email;
        hotelResObj.Remarks = remarks;
        hotelResObj.Dob = dob;
        hotelResObj.Nationality = nationality;
        hotelResObj.BillingType = billingType;
        hotelResObj.AdvanceAmount = advanceAmount;
        hotelResObj.CreditCardNo = creditCardNo;
        hotelResObj.RoomTypes = roomTypes;
        hotelResObj.RoomIds = roomIds;

        console.log(hotelResObj);
        var hotelReservationObj = JSON.stringify(hotelResObj);

        $.ajax({
            url: "/RoomBooking/SaveRoomBooking",
            type: "POST",
            data: { hotelReservationObj: hotelReservationObj },
            beforeSend: function () {
                $.blockUI({
                    timeout: 0,
                    message: '<h1><img src="/Content/Image/ajax-loader.gif" /> Processing...</h1>'
                });
            },
            success: function (data) {
                $.unblockUI();

            },
            complete: function () {
                $.unblockUI();
            },
            error: function (data) {
                $.unblockUI();
                bootbox.alert("Slow Internet Connection").css('margin-top', (($(window).height() / 4)));
            }
        });
    }
});