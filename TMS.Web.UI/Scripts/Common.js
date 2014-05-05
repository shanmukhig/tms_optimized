var d = $('<div class="modal fade" id="processing" tabindex="-1" role="dialog" data-backdrop="static" data-keyboard="false" aria-hidden="true"><div class="modal-dialog"><div class="modal-content"><div class="modal-body"><div class="row"><div class="col-md-5"></div><i class="fa fa-spinner fa-spin fa-2x"></i></div></div></div></div></div>');

$('body').delegate('span i.fa-plus-square, i.fa-minus-square', 'click', function (e) {
  $(this).toggleClass('fa-minus-square fa-plus-square');
  $($(this).parent().parent().parent().next()).slideToggle();
});

$('body').delegate('i.fa-chevron-up.pull-right, i.fa-chevron-down.pull-right', 'click', function (e) {
  $(e.target).toggleClass('fa-chevron-up fa-chevron-down');
  $($($(e.target).closest('ul')).children()[1]).slideToggle();
});

$(document).ready(function() {
  $('span i.fa-print').click(function() {
    window.print();
  });
});

if (!String.format) {
  String.format = function(format) {
    var args = Array.prototype.slice.call(arguments, 1);
    return format.replace(/{(\d+)}/g, function(match, number) { 
      return typeof args[number] != 'undefined'
        ? args[number] 
        : match
      ;
    });
  };
}

$('body').delegate('#dataTables-example > tbody > tr > td i.fa-check-square, i.fa-square-o', 'click', function () {
  $(this).toggleClass('fa-check-square fa-square-o');
});

$('body').delegate('span i.fa-check-square, i.fa-square-o', 'click', function (e) {
  //alert('1');
  $(this).closest('tbody>tr').siblings().each(function () {
    $(this).find('td span i.fa-check-square').removeClass('fa-check-square').addClass('fa-square-o');
  });
  $(this).removeClass('fa-square-o').addClass('fa-check-square');
});

$('body').delegate('span i.fa-times', 'click', function () {
  var tr = $($(this).parent().parent().parent().next());
  tr.fadeOut('slow', function() { tr.remove(); });
  tr = $(this).closest('tr');
  tr.fadeOut('slow', function() { tr.remove(); });
});

$('body').delegate('span i.glyphicon-remove', 'click', function () {
  var tr = $(this).closest('tr');
  tr.fadeOut('slow', function() {
    tr.remove();
  });
});

$(function() {
  $('body').delegate('[data-toggle="modal"]', 'click', function(e) {
    if ($(this).attr('data-uri') == '' || $(this).attr('data-uri') == undefined)
      return;
    e.preventDefault();

    $.ajax({
      type: 'GET',
      contentType: 'application/json',
      url: $(this).attr('data-uri'),
      //data: JSON.stringify(lead),
      success: function (data) {
        var modal, modalDialog, modalContent;
        modal = $('<div class="modal fade" data-backdrop="static" data-keyboard="false" />');
        modalDialog = $('<div class="modal-dialog" />');
        modalContent = $('<div class="modal-content" />');

        modal.modal('hide')
          .append(modalDialog)
          .on('hidden.bs.modal', function () { $(this).remove(); })
          .appendTo('body');

        modalDialog.append(modalContent);

        modalContent.html(data);
        modal.modal('show');
      },
      failure: function (result) {
        Messenger().post({
          message: 'There was an explosion while processing your request.' + data,
          type: 'error',
          showCloseButton: true
        });
      },
      beforeSend: function () {
        d.modal('hide').on('hidden.bs.modal', function () { $(this).remove(); }).appendTo('body');
        d.modal('show');
      },
      complete: function() {
        $(d).modal('hide');
      }
    });

    /*$.get($(this).attr('data-uri'), function() {
    }).done(function(data) {
      var modal, modalDialog, modalContent;
      modal = $('<div class="modal fade" />');
      modalDialog = $('<div class="modal-dialog" />');
      modalContent = $('<div class="modal-content" />');

      modal.modal('hide')
        .append(modalDialog)
        .on('hidden.bs.modal', function() { $(this).remove(); })
        .appendTo('body');

      modalDialog.append(modalContent);

      modalContent.html(data);
      modal.modal('show');
    }).fail(function(data) {
      Messenger().post({
        message: 'There was an explosion while processing your request.' + data,
        type: 'error',
        showCloseButton: true
      });
    });*/
  });
});

/*$.ajaxSetup({
  beforeSend: function() {
    alert('start');
  },
  complete: function() {
    alert('complete');
  },
  global: false
});*/

//$('span i.fa-')

$('nav div ul li.lisp').click(function ()
{
//  alert($(this).html());
  $(this).append('<span class="pull-right"><i class="fa fa-spin fa-spinner fa-lg fa-fw"></span>');
  window.location = $(this).find('span').attr('data-uri');
});

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

$('body').delegate('#communicationDetailSave', 'click', function () {
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
  else if (h.indexOf('fa-print') > -1)
    r = 8;
  return r;
}