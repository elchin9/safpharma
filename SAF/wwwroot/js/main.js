"use strict";

$(document).ready(function(){
    $(document).on("click", ".icon-left", function(){
        $(".left-wrapper").width(150);
        $(".menu-words").hide();
        $(".menu-icons").show();
        $(".icon-left").addClass("icon-right");
        $(".dashboard-logo").addClass("mini-logo");
        $(".right-wrapper").css("padding", "80px 0px 80px 200px");
        $(".icon-left").children().first().attr("src", "images/Component 53 – 1.svg")
    });
    
    $(document).on("click", ".icon-right", function(){
        $(".left-wrapper").width(300);
        $(".menu-words").show();
        $(".menu-icons").hide();
        $(".icon-left").removeClass("icon-right");
        $(".dashboard-logo").removeClass("mini-logo");
        $(".right-wrapper").css("padding", "80px 0px 80px 340px");
        $(".icon-left").children().first().attr("src", "images/Component 53 – 12.svg")
    });

    $(document).on("change", ".my-checked", function(){
        if ($(".my-checked").is(':checked')) {
            console.log("ok");
            $("tbody input").prop("checked", true)
            
        }
        else {
            console.log("ok2");
            $("tbody input").prop("checked", false);
        }
    });

    $(document).on("click", ".click-tbody tr", function(){
        $(".modal-title").text($(this).children().eq(1).text())
        $(".modal-body p").text($(this).children().eq(0).eq(0).text());
    });

    $(document).on("click", ".update-body tr", function(){
        $(".update-body tr.active-tr").removeClass("active-tr");
        $(this).toggleClass("active-tr");
    });


    $("#sendSms").click(function (e) {
        e.preventDefault();
        var data = {};
        var doctors = [];

        for (var i = 0; i < $(".doctorId").length; i++) {
            if ($("input.doctorId").eq(i).next().children().eq(0).is(":checked")) {
                doctors.push($("input.doctorId").eq(i).val());
            }

        }

        data.header = $("#smsHeader").val();
        data.body = $("#smsBody").val();
        data.doctors = doctors;

        $.ajax({
            type: "POST",
            url: "/AJAX/SendSms",
            data: data,
            success: function (d) {
                $(".btn-success-custom").click();
            },
            error: function (a) {
            }
        });

        $("#smsHeader").val("");
        $("#smsBody").val("");
    });
});
