<?php
$sidebar_args = array(
		'id' => 'right-sidebar',
		'name' => 'Main Sidebar',
		'before_widget' => '<div class="sidebar">',
	    'after_widget'  => "</div>",
	    'before_title'  => '<h3 class="widgettitle">',
	    'after_title'   => "</h3>",		
		);

register_sidebar( $sidebar_args );

register_nav_menu('main-menu', "This is my top site menu");

add_action( 'wp_enqueue_scripts', 'tlr_enqueue_scripts' );

function tlr_enqueue_scripts() {
	wp_enqueue_script( 'jquery' );
}
?>;