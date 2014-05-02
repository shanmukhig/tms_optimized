function validateCustom() {
  var i = true;
  i &= validateInput('#AmountQuoted', 'Amount quoted required.', 'Amount should be positive integer.', 'left', intRegEx);
  i &= validateDD('#CourseId', 'Course Title required.', 'left');
  i &= validateDD('#ServiceRequired', 'Service type required.', 'left');
  return i;
}