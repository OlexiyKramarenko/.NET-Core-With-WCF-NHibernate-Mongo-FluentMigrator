function Toggle(item) {
	obj = document.getElementById(item);
	visible = (obj.style.display != "none")
	key = document.getElementById("x" + item);
	if (visible) {
		obj.style.display = "none";
		key.innerHTML = "<table class='nav-tree-item'><tr><td><img class='img_folder'></td><td><b>Articles</b></table>";
	} else {
		obj.style.display = "block";
		key.innerHTML = "<table class='nav-tree-item'><tr><td><img class='img_textfolder'></td><td><b>Articles</b></table>";
	}
}
