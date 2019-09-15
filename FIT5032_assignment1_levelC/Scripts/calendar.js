$(document).ready(function () {
    var booking = [];
    $(".booking").each(function () {
        var room_id = $(".room_id", this).text().trim();
        var hotel_name = $(".hotel_name", this).text().trim();
        var checkin_date = $(".checkin_date", this).text().trim();
        var checkout_date = $(".checkout_date", this).text().trim();
        var room_type = $(".room_type", this).text().trim();
        var book = {
            "room_id": room_id,
            "hotel_name": hotel_name,
            "checkin_date": checkin_date,
            "checkout_date": checkout_date,
            "room_type": room_type
        };
        booking.push(book);
    });


    $("#calendar").fullCalendar({
        locale: 'au',
        events: booking,
        dayClick: function (date, allDay, jsEvent, view) {
            var d = new Date(date);
            var m = moment(d).format("YYYY-MM-DD");
            m = encodeURIComponent(m)
            var uri = "/Bookings/Create?date=" + m;
            $(location).attr('href', uri);
        }
    });
});


