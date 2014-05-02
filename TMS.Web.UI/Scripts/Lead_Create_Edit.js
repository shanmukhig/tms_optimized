Messenger.options = {
    extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right',
    theme: 'air'
  }

var date = new Date();
date.setDate(date.getDate() - 1);

var endDate = new Date();
endDate.setFullYear(endDate.getFullYear() + 1);

function setDateParams(controlName, pickTime) {
  var format = pickTime == true ? "dddd MMMM, DD YYYY HH:mm" : "dddd MMMM, DD YYYY";
  $(controlName).datetimepicker({
    format: format,
    keyboardNavigation: true,
    lanugage: 'en',
    pickTime: pickTime,
    minDate: date,
    maxDate: endDate,
    todayHighlight: true,
    sideBySide: pickTime ? true : false,
    show: true,
    defaultDate: '',
    autoclose: true
  });
}

$(document).ready(function() {
  setDateParams('#expectedDateOfJoin', false);
  setDateParams('#demoDateTime', true);
});

/*$('body').delegate('span i.glyphicon-remove', 'click', function () {
  var tr = $(this).closest('tr');
  tr.fadeOut('slow', function() { tr.remove(); });
});*/

$('body').delegate('span i.fa-check-square, i.fa-square-o', 'click', function(e) {
  $(this).closest('tbody>tr').siblings().each(function() {
    $(this).find('td span i.fa-check-square').removeClass('fa-check-square').addClass('fa-square-o');
  });
  $(this).removeClass('fa-square-o').addClass('fa-check-square');
});

$('body').delegate('#communicationDetailSave', 'click', function() {
  if (validateCustom()) {
    var row = '<tr><td><span class="pull-right"><i class="fa fa-lg fa-square-o"></i></span></td><td>{0}</td><td>{1}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>';
    var format = String.format(row, $('#CommunicationType').html().replace('<span class="caret"></span>', ''), $('#Uri').val());
    $('#communicationDetail > tbody').append(format);
    $('#communicationDetailSave').closest('div.modal').modal('hide');

    Messenger().post({
          message: 'Communication detail added successfully.',
          type: 'success',
          showCloseButton: true
        });
  }
});

$('body').delegate('#BestTimeSave', 'click', function() {
  if (validateCustom()) {
    var row = '<tr><td><i class="fa fa-clock-o fa-lg fa-fw"></i>{0}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>';
    var format = String.format(row, $('#BestTimeToContact').val());
    $('#bestTimetoContact > tbody').append(format);
    $('#BestTimeSave').closest('div.modal').modal('hide');

    Messenger().post({
          message: 'Best time to contact added successfully.',
          type: 'success',
          showCloseButton: true
        });
  }
});

$('body').delegate('#ServiceRequiredSave', 'click', function() {
  if (validateCustom()) {
    var row = '<tr><td><input type="hidden" value="{0},{1},{2}">{3}</td><td>{4}</td><td class="text-right"><i class="fa fa-usd fa-fw"></i>{2}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>';
    var c = $('#CourseId').find('option:selected');
    var s = $('#ServiceRequired').find('option:selected');
    var p = $('#AmountQuoted').val();
    var format = String.format(row, c.val(), s.val(), p, c.text().split(', ')[0].split(': ')[1], s.text());
    $('#courseRequired > tbody').append(format);
    $('#ServiceRequiredSave').closest('div.modal').modal('hide');

    Messenger().post({
          message: 'Course detail added successfully.',
          type: 'success',
          showCloseButton: true
        });

  }
});

function getCommType(t) {
  var h = $(t).html();
  var r = 0;
  if (h.indexOf('fa-envelope') > -1)
    r = 1;
  else if (h.indexOf('fa-phone') > -1)
    r = 2;
  else if (h.indexOf('fa-mobile') > -1)
    r = 3;
  else if (h.indexOf('fa-skype') > -1)
    r = 4;
  else if (h.indexOf('fa-twitter') > -1)
    r = 5;
  else if (h.indexOf('fa-facebook') > -1)
    r = 6;
  else if (h.indexOf('fa-linkedin') > -1)
    r = 7;
  return r;
}

$('#saveLead').click(function() {
  if (validateLead()) {
    var lead = {
      Salutation: $('#Salutation').val(),
      FirstName: $('#FirstName').val(),
      LastName: $('#LastName').val(),
      LeadType: $('#LeadType').val(),
      LeadSource: $('#LeadSource').val(),
      City: $('#City').val(),
      Country: $('#Country').val(),
      ReferredBy: $('#ReferredBy').val(),
      ClientStatus: $('#ClientStatus').val(),
      AssignedTo: $('#AssignedTo').val(),
      ExpectedDateOfJoin: new moment($('#ExpectedDateOfJoin').val(), 'dddd MMMM, DD YYYY'),
      DemoDateTime: new moment($('#DemoDateTime').val(), 'dddd MMMM, DD YYYY HH:mm'),
      CommunicationDetails : $.map($("#communicationDetail tr:gt(1)"), function(i) { var tds = $(i).children('td');
        return {CommunicationType:getCommType(tds[1]),Uri:$(tds[2]).html(),IsPreferred:$(tds[0]).html().indexOf('fa-check-square') > -1 ? true : false};
      }),
      BestTimeToContact: $.map($("#bestTimetoContact tr:gt(0)").find('td i.fa-clock-o'), function(i){ return new moment($(i).closest('td').html().replace('<i class="fa fa-clock-o fa-lg fa-fw"></i>', ''), 'dddd MMMM, DD YYYY HH:mm'); }),
      Courses: $.map($("#courseRequired tr:gt(1)").find('input'), function(i) { var a = $(i).val().split(','); return { CourseId: a[0], AmountQuoted: a[2], ServiceRequired: a[1] }; }),
      Description: $('#Description').val(),
      Status: $('#Status').val(),
    };
    if (!isCreate())
      lead.Id = $('#leadForm').attr('uid');

    $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: $('#leadForm').attr('action'),
      data: JSON.stringify(lead),
      success: function(data) {
        Messenger().post({
          message: String.format('Lead {0} successfully.', isCreate() ? 'created' : 'Updated'),
          type: 'success',
          showCloseButton: true
        });
      },
      failure: function(result) {
        Messenger().post({
          message: String.format('Failed to {0} Lead. Error: {1}', isCreate() ? 'create' : 'Update', result),
          type: 'success',
          showCloseButton: true
        });
      }
    });
  }
});

function isCreate() {
  var i = $('#leadForm').attr('uid');
  return i == undefined || i == '';
}


/*function submitConfirm(controlName, text, action) {
  $(controlName).confirmation({
    'animation': true,
    'container': 'body',
    'title': text,
    'btnOkLabel': '<i class="glyphicon glyphicon-ok"></i>',
    'btnCancelLabel': '<i class="glyphicon glyphicon-remove"></i>',
    'singleton': true,
    'popout' : true,
    'placement': 'bottom',
    'btnCancelClass': 'btn btn-outline btn-warning btn-xs',
    'btnOkClass': 'btn btn-outline btn-info btn-xs',
    'onConfirm': function () {
      $(controlName).confirmation('hide');
      action();
    },
    'onCancel': function () {
      $(controlName).confirmation('hide');
    }
  });
}

(function($) {
  $.fn.pascalCaseToPrettyString = function(s) {
    return s.replace(/([A-Z])/g, function($1) { return " " + $1; });
  }
  $.fn.stringToTitleCase = function(s) {
    return s.replace(/\w+/g, function(w) { return w[0].toUpperCase() + w.slice(1).toLowerCase(); });
  }
});*/

/*$('body').delegate('td i.fa-plus-square', 'click', function (e) {
  $(e.target).toggleClass('fa-minus-square fa-plus-square');
  $($($(e.target).parent('td')[0]).parent('tr').next()).slideToggle();
});

$('body').delegate('td i.fa-minus-square', 'click', function (e) {
  $(e.target).toggleClass('fa-plus-square fa-minus-square ');
  $($($(e.target).parent('td')[0]).parent('tr').next()).slideToggle();
});*/