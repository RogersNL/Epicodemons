$(document).ready(function(){
  $(".winner").on('click',function(){
    $(".enemySprite").addClass('animated hinge').one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
    function() {
      $(".enemySprite").hide();
      $(".winner").hide();
      $(".rivalSprite").fadeIn();
      $(".rival").first().show();
    });
  });
  $(".rival").click(function() {
    $(this).hide();
    $(this).next().show();
  });
});
