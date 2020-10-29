//Thêm class 'active' vào nơi có thẻ a trong class nav và đồng thời bỏ class 'active' ở cái đang chọn
$(function () {
    $('.nav a').filter(function () { return this.href == location.href }).parent().addClass('active').siblings().removeClass('active')
    $('.nav a').click(function () {
        $(this).parent().addClass('active').siblings().removeClass('active')
    })
})