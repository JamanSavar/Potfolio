// JScript source code
var DayName1 = { en: ["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"],heb: ["יום ראשון","יום שני","יום שלישי","יום רביעי","יום חמישי","יום שישי","שבת"] };
var MonthName1 = { en: ["January","February","March","April","May","June","July","August","September","October","November","December"],heb: ["ינואר","פברואר","מרץ","אפריל","מאי","יוני","יולי","אוגוסט","ספטמבר","אוקטובר","נובמבר","דצמבר"] };



var oneMinute1 = 1000 * 60;
var intervalObject1 = new Object();
intervalObject1["yyyy"] = 1000 * 60 * 60 * 24 * 365;
intervalObject1["m"] = 1000 * 60 * 60 * 24 * 30.333;
intervalObject1["d"] = 1000 * 60 * 60 * 24;


function DateAdd(dateAddObj)
{
    this.interval = dateAddObj.interval;
    this.number = dateAddObj.number;
    this.date = dateAddObj.date;
    this.language = dateAddObj.language;
    this.calculate1 = calculate1;
    this.calculate1();
}

Date.prototype.DateAdd = DateAdd;




function calculate1()
{
    var paramDate = new String(this.date);
    splitDate = paramDate.split("/");
    paramDateYear = splitDate[2];
    paramDateMonth = splitDate[1] - 1;
    paramDateDay = splitDate[0];
    if (paramDateMonth > 12)
    {
        alert("Invalid Month!");
        return false;
    }
    if (paramDateDay > 31)
    {
        alert("Invalid Day!");
        return false;
    }
    var paramDateObject = new Date(paramDateYear,paramDateMonth,paramDateDay);
    paramDateObject.setHours(0);
    paramDateObject.setMinutes(0);
    paramDateObject.setSeconds(0);
    paramDateObject.getTimezoneOffset() * oneMinute1;
    var paramDateObjectTime = paramDateObject.getTime();
    if (typeof intervalObject1[this.interval] == "undefined")
    {
        alert("Interval is invalid!");
        return false;
    }
    intervalObject1[this.interval] = intervalObject1[this.interval] * this.number;
    var newDateTime = paramDateObjectTime + parseInt(intervalObject1[this.interval]);
    var newDateObject = new Date(newDateTime);
    if (this.language == "heb")
    {
        var newDateObjectWeekDayName1 = DayName1.heb[newDateObject.getDay()];
        var newDateObjectMonthName1 = MonthName1.heb[newDateObject.getMonth()];
        var newDateObjectMonthDay = newDateObject.getDate();
    }
    else
    {
        var newDateObjectWeekDayName1 = DayName1.en[newDateObject.getDay()];
        var newDateObjectMonthName1 = MonthName1.en[newDateObject.getMonth()];
        var newDateObjectMonthDay = newDateObject.getDate();
    }

    var newDateObjectYear = newDateObject.getFullYear();
    this.weekDay = newDateObjectWeekDayName1;
    //this.month = newDateObjectMonthName1;
    this.month = newDateObject.getMonth() + 1;
    if (this.month < 10)
    {
        this.month = "0" + this.month.toString();
    }
    this.monthDay = newDateObjectMonthDay;
    this.year = newDateObjectYear;

    if (this.monthDay < 10)
    {
        this.monthDay = "0" + this.monthDay.toString();
    }
}
