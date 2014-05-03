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