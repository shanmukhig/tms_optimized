Messenger.options = {
    extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right',
    theme: 'air'
  }

$(document).ready(function() {
  setDateParams('#doj', false);
  setDateParams('#dor', false);
});

/*$('body').delegate('span i.glyphicon-remove', 'click', function () {
  var tr = $(this).closest('tr');
  tr.fadeOut('slow', function() { tr.remove(); });
});*/

$('body').delegate('#courseDetailSave', 'click', function () {
  if (validateCustom()) {
    var c = $('#CourseId').find('option:selected');
    var format = String.format('<tr><td class="col-md-5"><input type="hidden" value="{0}">{1}</td><td class="col-md-5">{2} years</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>', c.val(), c.text().split(', ')[0].split(': ')[1], $('#RelevantExperience').val());
    $('#courseDetail > tbody').append(format);
    $('#courseDetailSave').closest('div.modal').modal('hide');

    Messenger().post({
          message: 'Course Detail added successfully.',
          type: 'success',
          showCloseButton: true
        });
  }
});

$('body').delegate('#certificationDetailSave', 'click', function () {
  if (validateCustom()) {
    var format = String.format('<tr><td class="col-md-3">{0}</td><td class="col-md-3">{1}</td><td class="col-md-2">{2}</td><td class="col-md-2">{3}</td><td class="col-md-2">{4}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>', $('#Title').val(), $('#CertifyingCompany').val(), $('#CertifiedDate').val(), $('#ValidThru').val(), $('#Score').val());
    $('#certifications > tbody').append(format);
    $('#certificationDetailSave').closest('div.modal').modal('hide');

    Messenger().post({
          message: 'Course detail added successfully.',
          type: 'success',
          showCloseButton: true
        });
  }
});

$('body').delegate('#paymentsMadeSave', 'click', function () {
  if (validateCustom()) {
    var c = $('#PaymentMadeBy').find('option:selected');
    var format = String.format('<tr><td class="col-md-3"><input type="hidden" value="{4}">{0}</td><td class="col-md-3">{1}</td><td class="col-md-2">{2}</td><td class="col-md-2">{3}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>', $('#Amount').val(), $('#MadeOn').val(), c.text(), $('#PaymentType').val(), c.val());
    $('#paymentsMade > tbody').append(format);
    $('#paymentsMadeSave').closest('div.modal').modal('hide');

    Messenger().post({
      message: 'Course detail added successfully.',
      type: 'success',
      showCloseButton: true
    });
  }
});

$('i.fa-minus-circle').click(function() {
  $('#Rating').find('i.fa-star-half-empty, i.fa-star, i.fa-star-o').each(function () { reSetStars($(this)); });
});

$('i.fa-star-o, i.fa-star-half-empty, i.fa-star').click(function () {
  if ($(this).hasClass('fa-star')) {
    $(this).removeClass('fa-star').addClass('fa-star-half-empty');
  }
  else if ($(this).hasClass('fa-star-half-empty')) {
    $(this).removeClass('fa-star-half-empty').addClass('fa-star');
  }
  else if ($(this).hasClass('fa-star-o')) {
    $(this).removeClass('fa-star-o').addClass('fa-star-half-empty');
  }
  $(this).prevAll().each(function () { setStars($(this)); });
  $(this).nextAll().each(function() { reSetStars($(this)); });
});

function setStars(e) {
  if (e.hasClass('fa-minus-circle'))
    return;
  e.removeClass('fa-star-half-empty').removeClass('fa-star-o').addClass('fa-star');
}

function reSetStars(e) {
  if (e.hasClass('fa-minus-circle'))
    return;
  e.removeClass('fa-star-half-empty').removeClass('fa-star').addClass('fa-star-o');
}

$('#saveInstructor').click(function () {
  if (validateInstructor()) {
    /*var lead = {
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
      lead.Id = $('#leadCreateForm').attr('leadId');

    $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: $('#leadCreateForm').attr('action'),
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
    });*/
  }
});

function isCreate() {
  var i = $('#instructorCreateForm').attr('instructorId');
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