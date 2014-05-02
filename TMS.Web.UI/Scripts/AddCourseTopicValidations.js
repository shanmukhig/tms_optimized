function validateCustom() {
  var i = true;
  i = i & validateInput('#addCourseTitle', 'Course title required.', 'Course title should be a valid string.', 'left', stringRegEx);
  if ($('#addCourseDuration').length > 0)
    i = i & validateInput('#addCourseDuration', 'Duration required', 'Duration should be a valid number', 'left', intRegEx);
  return i;
}