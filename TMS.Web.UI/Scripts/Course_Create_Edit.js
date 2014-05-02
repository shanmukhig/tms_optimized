Messenger.options = {
    extraClasses: 'messenger-fixed messenger-on-bottom messenger-on-right',
    theme: 'air'
  }

$('body').delegate('#AddCourseTopic', 'click', function() {
  if (validateCustom()) {
    var id = $('#cid').val();
    if (id == 0)
      $('#coursesAdded > tbody').append(String.format('<tr><td><span><i class="fa fa-fw fa-minus-square" style="cursor: pointer"></i></span>  {0}</td><td>{1}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="fa fa-times fa-lg fa-al"></i></span></td></tr><tr style=""><td colspan="3" style="border-top:none;"><div class="table-responsive"><table class="table table-hover table-condensed" id="{2}"><tbody><tr><td colspan="4"><span class="btn btn-primary btn-xs btn-primary btn-outline pull-right" data-toggle="modal" data-uri="/tmsweb/Course/AddCourseTopic?time=minutes&amp;cid={2}" data-style="zoom-out"><i class="glyphicon glyphicon-plus"></i></span></td></tr></tbody></table></div></td></tr>', $('#addCourseTitle').val(), '0 hours 0 minutes', $('#coursesAdded').find('table').length + 1));
    else {
      $(String.format('#{0} > tbody', id)).append(String.format('<tr><td class="col-md-1"></td><td class="col-md-7"><span><i class="fa fa-hand-o-right fa-fw" style="cursor: pointer"></i></span>  {0}</td><td class="col-md-3">{1} minutes</td><td class="col-md-1"><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>', $('#addCourseTitle').val(), $('#addCourseDuration').val()));
      $(String.format('#{0}', id)).parent().parent().parent('tr').prev().find('td:eq(1)').html(getMinutes($(String.format('#{0} > tbody > tr', id)).find('td:eq(2)').sumHTML()));
      $('#Duration').val(getMinutes($('#coursesAdded > tbody').find('table').parent().parent().parent().prev().find('td:eq(1)').sumHTML1()));
    }

    $('#AddCourseTopic').closest('div.modal').modal('hide');

    Messenger().post({
      message: 'Course Topic added successfully.',
      type: 'success',
      showCloseButton: true
    });
  }
});

$('body').delegate('span i.fa-times', 'click', function () {
  setTimeout(function() { $('#Duration').val(getMinutes($('#coursesAdded > tbody').find('table').parent().parent().parent().prev().find('td:eq(1)').sumHTML1())); }, 1000);
});

$('body').delegate('span i.glyphicon-remove', 'click', function() {
  var id = $(this).parents().eq(4).attr('id');
  alert(id);
  setTimeout(function() {
    $(String.format('#{0}', id)).parent().parent().parent('tr').prev().find('td:eq(1)').html(getMinutes($(String.format('#{0} > tbody > tr:gt(0)', id)).find('td:eq(2)').sumHTML()));
    $('#Duration').val(getMinutes($('#coursesAdded > tbody').find('table').parent().parent().parent().prev().find('td:eq(1)').sumHTML1()));
  }, 1000);
});

function getMinutes(val) { return String.format('{0} hours {1} minutes', parseInt(val / 60), val % 60); }

(function ($) {
  $.fn.sumHTML = function () {
    var sum = 0;
    this.each(function () {
      var num = parseInt($(this).html(), 10);
      sum += (num || 0);
    });
    return sum;
  };
})(jQuery);

(function ($) {
  $.fn.sumHTML1 = function () {
    var sum = 0;
    this.each(function () {
      var s = $(this).html().split(' ');
      var num = parseInt(s[0]) * 60 + parseInt(s[2]);
      sum += (num || 0);
    });
    return sum;
  };
})(jQuery);

$('body').delegate('#AddInstructor', 'click', function() {
  if (validateCustom()) {
    var i = $('#InstructorSelect').val().split(',');
    var row = String.format('<tr><td><input type="hidden" value="{0}">{1}</td><td>{2} {4}</td><td>{3}</td><td><span class="btn btn-xs btn-danger btn-outline pull-right"><i class="glyphicon glyphicon-remove"></i></span></td></tr>', i[0], i[1], i[2], i[3], i[2] > 1 ? 'years' : 'year');
    $('#Instructor > tbody').append(row);
    $('#AddInstructor').closest('div.modal').modal('hide');
    Messenger().post({
      message: 'Communication detail added successfully.',
      type: 'success',
      showCloseButton: true
    });
  }
});

$('#saveCourse').click(function() {
  if (validateCourse()) {
    
  }
});