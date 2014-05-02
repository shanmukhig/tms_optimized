$(".dropdown-menu li a").click(function() {
  var b = $(this).parents(".input-group-btn").find('.btn');
  $(b).html($(this).closest('a').html() + ' <span class="caret"></span>');
  $(this).parents(".input-group-btn").find('.btn').val($(this).attr('data-value'));
});

function validateCustom() {
  var i = true;
  i = i & validateInput('#CommunicationType', 'Communication type required.');
  var t = $('#CommunicationType').val();
  var v = $('#Uri').val();

  var s = false;
  if (v == '' || v == undefined) {
    showPopover('#Uri', 'Id required.');
  } else {
    removePopover('#Uri');
    if (t == 1 && !emailRegEx.test(v))
      showPopover('#Uri', 'Email should be valid.');
    else if ((t == 2 || t == 3) && !phoneRegEx.test(v))
      showPopover('#Uri', 'Phone number should be valid.');
    else if (t > 3 && !alphaNumericRegex.test(v))
      showPopover('#Uri', 'Value should be valid.');
    else {
      removePopover('#Uri');
      s = true;
    }
  }
  return i & s;
}