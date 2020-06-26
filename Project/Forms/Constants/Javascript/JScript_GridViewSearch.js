var rowSearchStart = 1;
var textToSearch = "";
function SearchGridViewInDiv(divId, gridId, indexToSearch, searchForId)
{
    var div = document.getElementById(GetClientId(divId));
    var searchControll = document.getElementById(GetClientId(searchForId));
    var divHeight = 0;
    var searchColumns = "";
    var searchColumn = "";
    var searchText = "";
    var foundText = "";
    var matchedRowNumber = 0;
    var scrollTopHeight = 0;
    var gridRowHeight = "px";
    if (div != null)
    {
        divHeight = div.style.height;
        var gridView = document.getElementById(GetClientId(gridId));
        if (gridView != null)
        {
            var gridRows = gridView.getElementsByTagName("TR");
            if (gridRows != null)
            {
                if (gridRows.length > 1)
                {
                    if (searchControll != null)
                    {
                        searchFor = searchControll.value;
                        if (textToSearch != searchFor)
                        {
                            rowSearchStart = 1;
                        }
                        textToSearch = searchFor;
                    }
                    for (count = rowSearchStart; count < gridRows.length; count++)
                    {
                        searchColumns = gridRows[count].getElementsByTagName("TD");
                        if (searchColumns != null)
                        {
                            searchColumn = searchColumns[indexToSearch];
                            searchText = searchColumn.innerHTML;
                            if (searchFor != "")
                            {
                                searchFor = searchFor.replace(/[^a-zA-Z 0-9]+/g, '').toUpperCase();
                                searchText = searchText.replace(/[^a-zA-Z 0-9]+/g, '').toUpperCase();

                                if (searchText.indexOf(searchFor) == -1)
                                {

                                }
                                else
                                {
                                    matchedRowNumber = count;
                                    rowSearchStart = matchedRowNumber + 1;
                                    break;
                                }
                            }
                        }
                    }
                    if (matchedRowNumber != 0)
                    {
                        gridRowHeight = gridRows[gridRows.length - 1].style.height;
                        gridRowHeight = gridRowHeight.replace("px", "");
                        if (gridRowHeight == "")
                            gridRowHeight = "15px";
                        gridRows[matchedRowNumber].style.backgroundColor = "Tomato";
                        scrollTopHeight = parseInt(gridRowHeight) * matchedRowNumber;
                        div.scrollTop = parseInt(scrollTopHeight);
                    }
                }
            }
        }
    }
}