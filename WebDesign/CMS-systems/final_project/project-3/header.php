<!DOCTYPE HTML>
<html>
<head>
<title>
<?php
	/*
	 * Print the <title> tag based on what is being viewed.
	 */
	global $page, $paged;

	wp_title( '|', true, 'right' );

	// Add the blog name.
	bloginfo( 'name' );

	// Add the blog description for the home/front page.
	$site_description = get_bloginfo( 'description', 'display' );
	if ( $site_description && ( is_home() || is_front_page() ) )
		echo " | $site_description";

	// Add a page number if necessary:
	if ( $paged >= 2 || $page >= 2 )
		echo ' | ' . sprintf( __( 'Page %s', 'project3' ), max( $paged, $page ) );

	?>
</title>
<meta charset="<?php bloginfo( 'charset' ); ?>" />
<meta name="description" content="<?php bloginfo( 'description' ); ?>" />
<?php wp_head(); ?>
</head>
<body>
<div id="wrapper">
<div id="header-wrapper">
  <header id="header">
    <div class="5grid-layout">
      <div class="row">
        <div class="12u" id="logo"> <!-- Logo -->
          <h1><a href="<?php echo home_url(); ?>" class="mobileUI-site-name">
            <?php // Compatibility with versions of WordPress prior to 3.4.
						if ( function_exists( 'get_custom_header' ) ) {
							$header_image_width  = get_custom_header()->width;
							$header_image_height = get_custom_header()->height;
						} else {
							$header_image_width  = HEADER_IMAGE_WIDTH;
							$header_image_height = HEADER_IMAGE_HEIGHT;
						} ?>
            <img src="<?php header_image(); ?>" width="<?php echo $header_image_width; ?>" height="<?php echo $header_image_height; ?>" alt="Telerik Logo" /> </a> </h1>
        </div>
      </div>
    </div>
    <div class="5grid-layout">
      <div class="row">
        <div class="12u" id="menu">
          <div id="menu-wrapper">
            <?php

$defaults = array(
	'theme_location'  => '',
	'menu'            => 'main-menu',
	'container'       => 'nav',
	'container_class' => 'mobileUI-site-nav',
    'depth' => '3',
);
wp_nav_menu( $defaults );

?>
          </div>
        </div>
      </div>
    </div>
  </header>
</div>
<div id="page-wrapper" class="5grid-layout">
<?php get_template_part('horizontal','1'); ?>
<div class="5grid-layout">
<div class="row">
