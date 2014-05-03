$(document).ready(function () {
  setDateParams('#paymentDate', false);
});

function validateCustom() {
  var i = true;
  i &= validateDD('#PaymentType', 'Mode of Payment required.', 'left');
  i &= validateDD('#PaymentMadeBy', 'Payment made by required.', 'left');
  i &= validateInput('#MadeOn', 'Payment date required.', '', 'left');
  i &= validateInput('#Amount', 'Amount required.', 'Amount should be a positive integer.', 'left', intRegEx);
  return i;
}
