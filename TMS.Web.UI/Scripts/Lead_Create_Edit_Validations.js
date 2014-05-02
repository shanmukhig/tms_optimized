/*$('#leadCreateForm').validate({
  rules: {
    Salutation: { required: true },
    FirstName: { required: true },
    LastName: { required: true },
    LeadType: { required: true },
    LeadSource: { required: true },
    ClientStatus: { required: true },
    PreferredCommunicationType: { required: true },
    Status: { required: true },
    City: { required: true },
    Country: { required: true },
    bestTimetoContact: { ulValdator: true }
  },
  messages: {
    Salutation: { required: 'Salutation requried.' },
    FirstName: { required: 'First Title required.' },
    LastName: { required: 'Last Title required.' },
    LeadType: { required: 'Lead Type required.' },
    LeadSource: { required: 'Lead Source required.' },
    ClientStatus: { required: 'Client Status required.' },
    PreferredCommunicationType: { required: 'Preferred Comm. Type required.' },
    Status: { required: 'Status required.' },
    City: { required: 'City required.' },
    Country: { required: 'Country required.' },
    bestTimetoContact: { ulValdator: 'Best time to contact should contain at least one item.' }
  },
  showErrors: se,
  submitHandler: function (form) {
    var btn = $('#btnSave');
    btn.html('<i class="fa fa-spinner fa-spin"></i>');
    btn.attr('disabled', true);

    var lead = {
      BestTimeToContact: $.map($("#bestTimetoContact li"), function (i) { if ($(i).index() > 1) return new moment($(i).text(), 'dddd MMMM, DD YYYY HH:mm'); }),
      City: $('#City').val(),
      ClientStatus: $('#ClientStatus').val(),
      CommunicationDetails : $.map($("#communicationDetail li"), function(i) {if ($(i).index() > 1) {var a = $(i).text().split(':');return { CommunicationType: a[0], Uri: a[1] };}}),
      Country: $('#Country').val(),
      Courses: $.map($("#courseRequired li").find('input'), function(i) { var a = $(i).val().split(','); return { CourseId: a[0], AmountQuoted: a[2], ServiceRequired: a[1] }; }),
      DemoDateTime: new moment($('#DemoDateTime').val(), 'dddd MMMM, DD YYYY HH:mm'),
      Description: 'Enquiring for a course',
      ExpectedDateOfJoin: new moment($('#ExpectedDateOfJoin').val(), 'dddd MMMM, DD YYYY'),
      FirstName: $('#FirstName').val(),
      LastName: $('#LastName').val(),
      LeadSource: $('#LeadSource').val(),
      LeadType: $('#LeadType').val(),
      PreferredCommunicationType: $('#PreferredCommunicationType').val(),
      ReferredBy: $('#ReferredBy').val(),
      Salutation: $('#Salutation').val(),
      Status: $('#Status').val(),
    };
    if ($('#leadCreateForm').attr('leadId') != undefined)
      lead.Id = $('#leadCreateForm').attr('leadId');

    $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: $('#leadCreateForm').attr('action'),
      data: JSON.stringify(lead),
      success: function(data) {
        var uri = $('#leadCreateForm').attr('action').split('/');
        window.location = window.location.protocol + '//' + window.location.host + '/' + uri[1] + '/' + uri[2];
      },
      failure: function(result) {
        alert(result);
      }
    });
  }
});*/