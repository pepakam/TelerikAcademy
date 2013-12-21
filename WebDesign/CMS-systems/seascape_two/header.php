<!DOCTYPE HTML>
<html>

<head>
  <title><?php wp_title();?></title>
  <meta name="description" content="<?php bloginfo( 'description' ); ?>" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
  <link rel="stylesheet" href="<?php bloginfo('stylesheet_url'); ?>" type="text/css" media="all">
  <!-- modernizr enables HTML5 elements and feature detects -->
  <script type="text/javascript" src="<?php echo get_template_directory_uri(); ?>/js/modernizr-1.5.min.js"></script>
<?php wp_head(); ?>
</head>

<body>
  <div id="main">
    <header>
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1><a href="<?php echo home_url(); ?>">CSS3<span class="logo_colour">_seascape_two</span></a></h1>
          <h2>Simple. Contemporary. Website Template.</h2>
        </div>
      </div>
     
      <?php
       wp_nav_menu( array(
        'theme_location' => 'main-menu',
        'container' => 'nav', 
        'menu_class' => 'sf-menu',
        'menu_id' => 'nav'
         ) );
        ?>     
    </header>
    <div id="site_content">
      <ul id="images">
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/1.jpg" width="600" height="300" alt="seascape_one" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/2.jpg" width="600" height="300" alt="seascape_two" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/3.jpg" width="600" height="300" alt="seascape_three" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/4.jpg" width="600" height="300" alt="seascape_four" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/5.jpg" width="600" height="300" alt="seascape_five" /></li>
        <li><img src="<?php echo get_template_directory_uri(); ?>/images/6.jpg" width="600" height="300" alt="seascape_seascape" /></li>
      </ul>
      <?php get_sidebar('right-sidebar');?>
      	 <div class="content">