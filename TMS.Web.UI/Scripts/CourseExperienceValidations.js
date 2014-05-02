function validateCustom() {
  var i = true;
  i &= validateInput('#RelevantExperience', 'Experience required.', 'Experience should be positive number.', 'left', numberRegEx);
  i &= validateDD('#CourseId', 'Course Title required.', 'left');
  return i;
}