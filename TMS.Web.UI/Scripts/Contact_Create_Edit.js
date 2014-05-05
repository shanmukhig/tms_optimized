Messenger.options = {
    extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right',
    theme: 'air'
  }

//$(document).ready(function() {
//  setDateParams('#expectedDateOfJoin', false);
//  setDateParams('#demoDateTime', true);
//});

/*$('body').delegate('span i.glyphicon-remove', 'click', function () {
  var tr = $(this).closest('tr');
  tr.fadeOut('slow', function() { tr.remove(); });
});*/

//$('body').delegate('#BestTimeSave', 'click', function() {
//  if (validateCustom()) {
//    var row = '<tr><td><i class="fa fa-clock-o fa-lg fa-fw"></i>{0}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>';
//    var format = String.format(row, $('#BestTimeToContact').val());
//    $('#bestTimetoContact > tbody').append(format);
//    $('#BestTimeSave').closest('div.modal').modal('hide');

//    Messenger().post({
//          message: 'Best time to contact added successfully.',
//          type: 'success',
//          showCloseButton: true
//        });
//  }
//});

//$('body').delegate('#ServiceRequiredSave', 'click', function() {
//  if (validateCustom()) {
//    var row = '<tr><td><input type="hidden" value="{0},{1},{2}">{3}</td><td>{4}</td><td class="text-right"><i class="fa fa-usd fa-fw"></i>{2}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>';
//    var c = $('#CourseId').find('option:selected');
//    var s = $('#ServiceRequired').find('option:selected');
//    var p = $('#AmountQuoted').val();
//    var format = String.format(row, c.val(), s.val(), p, c.text().split(', ')[0].split(': ')[1], s.text());
//    $('#courseRequired > tbody').append(format);
//    $('#ServiceRequiredSave').closest('div.modal').modal('hide');

//    Messenger().post({
//          message: 'Course detail added successfully.',
//          type: 'success',
//          showCloseButton: true
//        });

//  }
//});

$('#saveContact').click(function () {
  if (validateContact()) {
    var contact = {
      Salutation: $('#Salutation').val(),
      FirstName: $('#FirstName').val(),
      LastName: $('#LastName').val(),
      Title: $('#Title').val(),
      CompanyName: $('#CompanyName').val(),
      ReferredBy: $('#ReferredBy').val(),
      City: $('#City').val(),
      Country: $('#Country').val(),
      State: $('#State').val(),
      Zip: $('#Zip').val(),
      Description: $('#Description').val(),
      Status: $('#Status').val(),
      CommunicationDetails : $.map($("#communicationDetail tr:gt(1)"), function(i) { var tds = $(i).children('td');
        return {CommunicationType:getCommType(tds[1]),Uri:$(tds[2]).html(),IsPreferred:$(tds[0]).html().indexOf('fa-check-square') > -1 ? true : false};
      }),
    };
    if (!isCreate())
      contact.Id = $('#contactForm').attr('uid');

    $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: $('#contactForm').attr('action'),
      data: JSON.stringify(contact),
      success: function() {
        Messenger().post({
          message: String.format('Contact {0} successfully.', isCreate() ? 'created' : 'Updated'),
          type: 'success',
          showCloseButton: true
        });
      },
      beforeSend: function() {
        d.modal('hide').on('hidden.bs.modal', function () { $(this).remove(); }).appendTo('body');
        d.modal('show');
      },
      complete: function() {
        $(d).modal('hide');
      },
      failure: function(result) {
        Messenger().post({
          message: String.format('Failed to {0} Contact. Error: {1}', isCreate() ? 'create' : 'Update', result),
          type: 'success',
          showCloseButton: true
        });
      }
    });
  }
});

function isCreate() {
  var i = $('#contactForm').attr('uid');
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