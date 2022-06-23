var last_focus_index = 0;
var mainfocus = 0;
var item_count = 0;
var button_count = 3;

function setFocusElement(e) {
	console.log("setFocusElement : keyCode : " + e.keyCode);
	console.log("mainfocus = " + mainfocus);
	switch (e.keyCode) {
		case TvKeyCode.KEY_ENTER:
			window.location.href = $("#id"+mainfocus).attr("href");
            break;
        case TvKeyCode.KEY_UP:
			if(mainfocus < item_count + 1 && mainfocus > 0){
				mainfocus = mainfocus - 1;
				hideItem(last_focus_index);
				showItem(mainfocus);
				last_focus_index=mainfocus;
			}
			break;
        case TvKeyCode.KEY_LEFT:
			if(mainfocus > item_count && mainfocus < item_count + button_count){
				if(mainfocus)
				mainfocus = mainfocus - 1;
				hideItem(last_focus_index);
				showItem(mainfocus);
				last_focus_index=mainfocus;
			}
	        break;
        case TvKeyCode.KEY_DOWN:
			if(mainfocus < item_count && mainfocus > -1){
				mainfocus = mainfocus + 1;
				hideItem(last_focus_index);
				showItem(mainfocus);
				last_focus_index=mainfocus;
			}
			break;
		case TvKeyCode.KEY_RIGHT:
			if(mainfocus > item_count - 1 && mainfocus < item_count + button_count - 1){
				mainfocus = mainfocus + 1;
				hideItem(last_focus_index);
				showItem(mainfocus);
				last_focus_index=mainfocus;
			}
            break;
    }
}

function showItem(index) {
	$("#id" + index).addClass("ui-btn-active");
	$("#id" + index).addClass("ui-focus");
	$("#li" + index).addClass("ui-focus");
}

function hideItem(index) {
	$("#id" + index).removeClass("ui-btn-active");
	$("#id" + index).removeClass("ui-focus");
	$("#li" + index).removeClass("ui-focus");
	if((index == item_count - 1) && $(".ui-btn-active").attr("id") && parseInt($(".ui-btn-active").attr("id").substr(2,1)) > item_count - 1){
		$(".ui-btn-active").removeClass("ui-btn-active");
	}
}

function showMovie(mId) {
	
}

function storageInit() {
	if(typeof(Storage)===undefined)
	{
		var msg = "Sorry, currently Tizen does not support web storage";		
		alert(msg);
		//document.getElementById('alertMessage').innerHTML = msg;
	} else {
		if(localStorage.getItem("server") === null){
			localStorage.setItem("server", "http://192.168.0.100/movies/");
		}
	}
}

$(document).ready(function(){
	/*if (window.tizen === undefined) {
		alert('This application needs to be run on Tizen device');
		//return;
		
	}*/

	storageInit();
	
	$.get(`${localStorage.getItem("server")}movielist.json`, function(data, status){
		var id = 0;
		item_count = data.length;
		
		$(data).each(function( index ) {
			var li = document.createElement(li);
    		var div = document.createElement(div);
			console.log( data[index].title );
			$("ul[data-role='listview']").append(`<li id="li${id}" data-corners="false" data-shadow="false" data-iconshadow="true" data-wrapperels="div" data-icon="arrow-r" data-iconpos="right" data-theme="c" class="ui-btn ui-btn-icon-right ui-li-has-arrow ui-li ui-btn-up-c"><div class="ui-btn-inner ui-li"><div class="ui-btn-text"><a id="id${id}" href="javascript:showMovie(${data[index].id})" style="box-shadow:0 0;" class="ui-link-inherit transition-animation">${data[index].title}</a></div><span class="ui-icon ui-icon-arrow-r ui-icon-shadow">&nbsp;</span></div></li>`);
			id = id+1;
		});

		if(id > 0){
			showItem(0);
		}

		console.log("page load complete!!!");
	 
		console.log("li count = " + item_count);

		$(".ui-controlgroup-controls").attr("style", "width:50%");

		$("#idl").attr("id","id"+id);
		$("#ids").attr("id","id"+(id+1));
    });
     
});