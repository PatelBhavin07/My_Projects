//3.When the Theme button is clicked the panel headers and the top navigation bar should display a green background colour

var btnTheme = document.getElementById('toogletheme');
btnTheme.addEventListener("click", toggleTheme);
var theme
function toggleTheme() {
    var headings = document.querySelectorAll('h4.head')
    if (theme =="h4.head") {
        for (var i = 0; i < headings.length; i++) {
            headings[i].style.backgroundColor = "#428bca";
        }theme = "#428bca"
    }//4.	When the Theme button is clicked again (toggled), the panel headers and the top navigation bar should display the default background colour
    else{
        for (var i = 0; i < headings.length; i++) {
            headings[i].style.backgroundColor = "#11C034"
        }
        theme = "h4.head"
    }
}


//1.When the “Display X, Y” button is hovered over, the Table should disappear and in its place the x/y co-ordinates of the mouse pointers position should display and update
// as the mouse is moved around the button surface area: 

var Coordinates = document.getElementById('XandY');
Coordinates.addEventListener("mousemove", displaycoordinates);
Coordinates.addEventListener("mouseleave",resetT);
function displaycoordinates(e) { 
    output.innerHTML = "Mouse X: " + e.offsetX + "<br>" + "Mouse Y: " + e.offsetY;
    output.style.fontWeight = "bold"
}                  
   //2.	When the mouse moves off the Button the Table should re-appear and the coordinates disappear.
function resetT(){
    output.innerHTML = 
    "<table class=\"ttable\" id=\"t\">"+
    "<thead class=\"tthead\">"+
        "<tr>"+
        "<th colspan=\"3\">Table Data</th>"+
        "</tr>"+
    "</thead>"+
    "<tbody class=\"ttbody\">"+
        "<tr>"+
            "<td rowspan=\"2\">1</td>"+
            "<td>2</td>"+
            "<td>3</td>"+
        "</tr>"+
        "<tr>"+
            "<td>4</td>"+
            "<td>5</td>"+
        "</tr>"+
        "<tr>"+
            "<td>6</td>"+
            "<td rowspan=\"2\">7</td>"+
            "<td>8</td>"+
        "</tr>"+
        "<tr>"+
            "<td>9</td>"+
            "<td>10</td>"+
        "</tr>"+
    "</tbody>"+
    "<tfoot class=\"ttfoot\">"+
            "<tr>"+
                "<td>11</td>"+
                "<td>12</td>"+
                "<td rowspan=\"2\">13</td>"+
            "</tr>"+
            "<tr>"+
                "<td>14</td>"+
                "<td>15</td>"+
            "</tr>"+
    "</tfoot>"+
"</table>"
}

//7. When the Swap Image  button is clicked, the default image should change and display another image (this can be found in the resources folder)

var Swap = document.getElementById('swpimg');
Swap.addEventListener("click", swapimage);
var img
function swapimage() {
    var image = document.querySelector(".image");
    if(img == "business") {
        image.src = "/assignment-resources/images/business.jpg";
        img = "sports"
    }
    //8. When the Swap Image button is clicked again (toggled), the default image should reappear
    else{
        image.src = "/assignment-resources/images/sports.jpg";
        img = "business"
    }
}

//5. When the Modal button is clicked, an image contained in div should appear (modal) as shown below:

var toggleModal = "off"
var mdldiv = document.getElementById('mdlimg');
var modalimg = document.getElementById('modalImg');
var peopleimg = new Image
peopleimg.src = "assignment-resources/images/people.jpg";
var btnmodal = document.getElementById('modalbtn');
btnmodal.onclick = function() {
    if(toggleModal == "off")
    {
        mdldiv.style.display = "block";
        modalimg.src = peopleimg.src;
        toggleModal = "on";
    }
    //6.	When the Modal button is clicked again (toggled), the Modal image should disappear. 
    else{
        mdldiv.style.display = "none";
        toggleModal = "off";
    }
}



