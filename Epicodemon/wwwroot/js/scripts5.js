$(document).ready(function(){
  $(".loser").on('click',function(){
    $(".fighterSprite").addClass('animated hinge').one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend",
    function() {
      $(".fighterSprite").hide();
      $(".loser").hide();
      // $(".rivalSprite").fadeIn();
      $(".rival").first().show();
    });
  });
  $(".rival").click(function() {
    $(this).hide();
    $(this).next().show();
  });
});
