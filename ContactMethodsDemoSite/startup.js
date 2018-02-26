
$(document).ready(function () {

    $.ajax({
        type: "GET",
        contentType: "application/text; charset=utf-8",
        datatype: "json",
        url: "ds/modelFromBuilder/ContactMethods/CampusNexus.GetAllEmails()?$expand=Person($select=FirstName)",
        beforeSend: function (XMLHttpRequest) {
            //Specifying this header ensures that the results will be returned as JSON.
            XMLHttpRequest.setRequestHeader("Accept", "application/text");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            $('#odataresult').html(XmlHttpRequest.responseText);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            errorHandler(XMLHttpRequest, textStatus, errorThrown);
        }
    });

    $.ajax({
        type: "GET",
        contentType: "application/text; charset=utf-8",
        datatype: "json",
        url: "ds/modelFromXml/ContactMethods/CampusNexus.GetAllEmails()?$expand=Person($select=FirstName)",
        beforeSend: function (XMLHttpRequest) {
            //Specifying this header ensures that the results will be returned as JSON.
            XMLHttpRequest.setRequestHeader("Accept", "application/text");
        },
        success: function (data, textStatus, XmlHttpRequest) {
            $('#badodataresult').html(XmlHttpRequest.responseText);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            errorHandler(XMLHttpRequest, textStatus, errorThrown);
        }
    });
}); 