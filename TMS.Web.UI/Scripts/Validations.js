function showPopover(e, m, p) {
  $(e).popover({
    animation: true,
    trigger: 'manual',
    placement: p == '' || p == undefined ? 'top' : p,
    content: String.format('<span class="text-warning"><i class="fa fa-exclamation-triangle fa-fw"></i>{0}</span>', m),
    html: true,
    container: $('form')
  });
  $(e).popover('show');
  $(e).closest('td').addClass('has-error').removeClass('has-success');
}

function removePopover(e) {
  $(e).popover('hide');
  $(e).popover('destroy');
  $(e).closest('td').removeClass('has-error').addClass('has-success');
}

function validateDD(e, m, p) {
  var i = false;
  var t = $(e).find('option:selected').val();
  if (t == '' || t == undefined)
    showPopover(e, m, p);
  else {
    removePopover(e);
    i = true;
  }
  return i;
}

function validateInputO(e, m, p, r) {
  var i = false;
  var t = $(e).val();
  if (t != '' && r != undefined && !r.test(t))
    showPopover(e, m, p);
  else {
    removePopover(e);
    i = true;
  }
  return i;
}

function validateInput(e, m1, m2, p, r) {
  var i = false;
  var t = $(e).val();
  if (t == '' || t == undefined)
    showPopover(e, m1, p);
  else {
    removePopover(e);
    if (r != undefined && !r.test(t))
      showPopover(e, m2, p);
    else {
      removePopover(e);
      i = true;
    }
  }
  return i;
}

function validateTable(e, m, p, c) {
  var i = false;
  if ($(e).find('tr').length < c)
    showPopover(e, m, p);
  else {
    i = true;
    removePopover(e);
  }
  return i;
}

function validatePreferred() {
  var i = false;
  if ($('#communicationDetail tr td span i.fa-check-square').length <= 0)
    showPopover('#communicationDetail', 'Preferred communication type required.');
  else {
    removePopover('#communicationDetail');
    i = true;
  }
  return i;
}

var intRegEx = /^(?=\d*[1-9])\d+$/;
var numberRegEx = /^[+]?([1-9][0-9]*(?:[\.][0-9]*)?|0*\.0*[1-9][0-9]*)(?:[eE][+-][0-9]+)?$/;
var stringRegEx = /^[a-z.,\s0-9\-_:]+$/i;
var alphaNumericRegex = /^[0-9a-z.,\s\-]+$/i;
var emailRegEx = /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/;
var phoneRegEx = /^(\+?1-?)?(\([2-9]([02-9]\d|1[02-9])\)|[2-9]([02-9]\d|1[02-9]))-?[2-9]([02-9]\d|1[02-9])-?\d{4}$/