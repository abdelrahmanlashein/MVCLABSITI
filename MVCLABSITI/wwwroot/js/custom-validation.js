$(function () {
    $.validator.addMethod("uniquename", function (value, element) {
      return true;
    });

    $.validator.unobtrusive.adapters.add("uniquename", [], function (options) {
        options.rules["uniquename"] = true;
        options.messages["uniquename"] = options.message;
    });
});
