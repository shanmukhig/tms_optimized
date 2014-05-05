Messenger.options = {
    extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right',
    theme: 'air'
  }

$(document).ready(function() {
  setDateParams('#dueDate', false);
});

$('#saveActivity').click(function () {
  if (validateActivity()) {
    var activity = {
      AssignedTo: $('#AssignedTo').val(),
      DueBy: $('#DueBy').val(),
      Priority: $('#Priority').val(),
      ActivityStatus: $('#ActivityStatus').val(),
      ActivityType: $('#ActivityType').val(),
      Status: $('#Status').val(),
      Notes: $('#Notes').val(),
    };
    if (!isCreate())
      activity.Id = $('#activityForm').attr('uid');

    $.ajax({
      type: 'POST',
      contentType: 'application/json',
      url: $('#activityForm').attr('action'),
      data: JSON.stringify(activity),
      success: function(data) {
        Messenger().post({
          message: String.format('Activity {0} successfully.', isCreate() ? 'created' : 'Updated'),
          type: 'success',
          showCloseButton: true
        });
      },
      failure: function(result) {
        Messenger().post({
          message: String.format('Failed to {0} Activity. Error: {1}', isCreate() ? 'create' : 'Update', result),
          type: 'success',
          showCloseButton: true
        });
      }
    });
  }
});

function isCreate() {
  var i = $('#activityForm').attr('uid');
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