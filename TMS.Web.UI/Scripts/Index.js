Messenger.options = {
    extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right',
    theme: 'flat'
  }

$('span i.fa-search').click(function () {
  var t = $(this).closest('div').find('input.form-control');
  if (t.val() == '' || t.val() == undefined) {
    Messenger().post({
      message: 'Search text required.',
        type: 'error',
        showCloseButton: true
    });
    return false;
  }
  window.location = t.attr('data-url').replace('%7BsearchString%7D', t.val());
  return true;
});

$(document).ready(function() {
  $('span i.fa-trash-o, i.fa-wheelchair, i.fa-check-square-o').click(function() {
    var d = $(this).hasClass('fa-trash-o') ? 'd' : $(this).hasClass('fa-wheelchair') ? 'i' : 'e';
    var ci = $('i.fa-check-square');
    if (ci.length > 0) {
      ci.each(function() {
        if (showMessage($(this), d)) {
          deleteEntity($(this).attr('data-value'), d, $(this));
        }
      });
    } else {
      Messenger().post({
        message: 'Please select at least one record.',
        type: 'error',
        showCloseButton: true
      });
    }
  });

    $('#dataTables-example').dataTable({
      'aoColumnDefs': [
        {
          'bSortable': false,
          'aTargets': [0]
        }
      ]
    });
});

function showMessage(p, d) {
  var t = p.closest('tr').find('td:last').html();
  if((t == 'Deleted' && d == 'd') || (t == "Active" && d == 'e') || (t == "Inactive" && d == 'i'))
  {
    Messenger().post({
      message: 'Record was already ' + t + '.',
      type: 'error',
      showCloseButton: true
    });
    return false;
  }
  return true;
}

function GetStatusMessage(d) {
  switch (d) {
  case 'd':
    return 'Deleted';
  case 'e':
    return 'Active';
  case 'i':
    return 'Inactive';
  default:
    return null;
  }
}

function GetMessage(a) {
  switch (a) {
  case 'd':
    return 'Successfully deleted.';
  case 'e':
    return 'Successfully enabled.';
  case 'i':
    return 'Successfully disabled.';
  default:
    return null;
  }
}

function GetPath(a, u) {
  var x = window.location.protocol + '//' + window.location.host + (window.location.pathname.indexOf('Search') > -1 ? window.location.pathname.replace('/Search', '') : window.location.pathname.replace('//', '/'));
  switch (a) {
  case 'd':
    x = x + '/delete/' + u;
    break;
  case 'e':
    x = x + '/enable/' + u;
    break;
  case 'i':
    x = x + '/disable/' + u;
    break;
  default:
    return null;
  }
  return x;
}

function deleteEntity(u, a, t) {
  $.ajax({
    type: 'DELETE',
    contentType: 'application/json',
    url: GetPath(a, u),
    success: function(data) {
      Messenger().post({
        message: GetMessage(a),
        type: 'success',
        showCloseButton: true
      });
      if (t != null || t != undefined) {
        t.closest('tr').find('td:last').html(GetStatusMessage(a));
      }
    },
    failure: function(result) {
      Messenger().post({
        message: 'There was an explosion while processing your request.' + result,
        type: 'info',
        showCloseButton: true
      });
    }
  });
}

$('input:text').keypress(function(e) {
  var c = e.keyCode ? e.keyCode : e.which;
  if (c == 13)
    $('span i.fa-search').click();
});

$('span i.fa-refresh').click(function () {
  $(this).addClass('fa-spin');
  window.location.reload();
});