$(document).ready(function () {

    $('input[type="checkbox"]').change(function () {
        if (!$(this).is(':checked')) {
            var li = $(this).closest('li');
            console.log('closest child -->' + li);
            // check all children 
            $('li input[type="checkbox"]', li).prop('checked', false);
        }
        else {
            var li = $(this).closest('li');
            console.log('closest child -->' + li);
            // check all children 
            console.log("hello -->>");
            $('li input[type="checkbox"]', li).prop('checked', true);

            // see if all siblings are checked
            var all = true;
            li.siblings().find('>input[type="checkbox"]').each(function () {
                if (!$(this).is(':checked')) all = false;
            });
            if (all) {
                // check parent checkbox
                $(this).closest('li').closest(':has(>input)')
                      .find('input[type="checkbox"]').prop('checked', true);
            }
        }
    });

    // add multiple Check / Uncheck functionality
    $("#allCheck").click(function () {
        console.log('called');
        if ($('#allCheck').is(":checked")) {
            $('.checkItem').prop('checked', true);

        } else {
            $('.checkItem').prop("checked", false);
        }
    });

    // if all child checkbox are selected, check the Parent checkbox
    $('input:checkbox').click(function () {

        console.log("FFF-->>" + ($("input:checkbox").length - 1));
        console.log("SSS-->>" + $("input:checkbox:checked").length);
        var totalLength = ($("input:checkbox").length - 1);
        var currentCheckedLength = $("input:checkbox:checked").length;
        if (totalLength == currentCheckedLength) {
            console.log(' equal');
            $("#allCheck").prop('checked', true);
        }
    });
});

var MenuPermission = {
    SaveMenuPermission: function () {

        var menuIds = new Array();

        $.each($('ul li input[type="checkbox"]:checked'), function (key, value) {
            
            menuIds.push($(value).attr("name"));
        });
        console.log(menuIds);
        var objMeuMapping = {
            MenuIds: menuIds,
            UserName: $('#username').val()

        }
        console.log(objMeuMapping);
        var mpurl = "/setting/SaveMenuPermission";
        var data = JSON.stringify(objMeuMapping);
        console.log(data);
        //alert(url)
        //UrlSettings.SaveMenuPermission,
        $.ajax({
            type: 'POST',
            data: { data: data },
            url: mpurl,
            success: function (response) {
                alert(""+response);
            }
        });

    },

    SetCheckedProp: function (checkboxname) {

        var param = 'input:checkbox[name=' + checkboxname + ']';
        if ($(param).is(':checked')) {
            $(param).attr('checked', true);
        } else {
            $(param).removeAttr('checked');
        }

    }
}