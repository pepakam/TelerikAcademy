<?php
	 //--------------CUSTOM HEADER----------------------------
	$custom_header = array(
	    'default-image'  => get_template_directory_uri() . '/css/images/headers/green.png',		
		'width' => apply_filters( 'project3', 1200 ),
		'height' => apply_filters( 'project3', 153 ),
		'default-text-color'     => 'fff',
	    'header-text'            => true,
	);
add_theme_support( 'custom-header', $custom_header );

	if ( ! function_exists( 'get_custom_header' ) ) {
		// This is all for compatibility with versions of WordPress prior to 3.4.

		define( 'HEADER_IMAGE', $custom_header['default-image'] );
		define( 'HEADER_IMAGE_WIDTH', $custom_header['width'] );
		define( 'HEADER_IMAGE_HEIGHT', $custom_header['height'] );
		define( 'HEADER_TEXTCOLOR', $custom_header_support['default-text-color'] );
		define( 'HEADER_TEXT', $custom_header_support['header-text'] );
		add_custom_image_header( $custom_header['wp-head-callback'], $custom_header['admin-head-callback'], $custom_header['admin-preview-callback
'] );
add_custom_background();
		
	}
	register_default_headers( array(
		'green' => array(
			'url' => '%s/css/images/headers/green.png',
			'thumbnail_url' => '%s//css/images/headers/green_thumbnail.png',
			'description' => __( 'Green', 'project3' )
		),
		'red' => array(
			'url' => '%s//css/images/headers/red.png',
			'thumbnail_url' => '%s//css/images/headers/red_thumbnail.png',
			'description' => __( 'Red', 'project3' )
		),
			'blue' => array(
			'url' => '%s//css/images/headers/blue.png',
			'thumbnail_url' => '%s//css/images/headers/blue_thumbnail.png',
			'description' => __( 'Blue', 'project3' )
		),
	) );
		

 //--------------STYLES AND SCRIPT---------------------------- 
function project3_scripts_styles() {
  wp_enqueue_style('core', get_template_directory_uri() . '/css/5grid/core.css', array(),'1.0', 'all');
  wp_enqueue_style('core-desktop', get_template_directory_uri() . '/css/5grid/core-desktop.css', array(),'1.0', 'all' );
  wp_enqueue_style('core-1200px', get_template_directory_uri() . '/css/5grid/core-1200px.css', array(),'1.0', 'all');
  wp_enqueue_style('core-noscript', get_template_directory_uri() . '/css/5grid/core-noscript.css', array(),'1.0', 'all' );
 wp_enqueue_style('project3-style', get_stylesheet_uri() );
  wp_enqueue_style('style-desktop', get_template_directory_uri() . '/css/style-desktop.css', array(),'1.0', 'all' );  
   wp_enqueue_script( 'jquery' );
   $query_args = array(
			'cond' => 'use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none'
			);
  wp_enqueue_script( 'init', add_query_arg( $query_args, get_template_directory_uri() . '/css/5grid/init.js' ), array('jquery') );
   
}     
add_action('wp_enqueue_scripts', 'project3_scripts_styles');

 //--------------SIDEBARS----------------------------  
if ( function_exists ('register_sidebar')) { 
    register_sidebar (array(
  'name' => __( 'Sidebar 1' ),
  'id' => 'sidebar1',   
  'description' => __( 'Widgets in this area will be shown on the sidebar1.' ),
  'before_title' => '<h2 class="widgettitle">',
  'after_title' => '</h2>',
	'before_widget' =>'<div id="%1$s" class="widget %2$s">',
	'after_widget'  => '</div>',   
));
}
if ( function_exists ('register_sidebar')) {
    register_sidebar (array(
  'name' => __( 'Sidebar 2' ),
  'id' => 'sidebar2',
  'description' => __( 'Widgets in this area will be shown on the sidebar2.' ),
  'before_title' => '<h2 class="widgettitle">',
  'after_title' => '</h2>',
	'before_widget' =>'<div id="%1$s" class="widget %2$s">',
	'after_widget'  => '</div>'
));
}
if ( function_exists ('register_sidebar')) { 
	register_sidebar( array(
		'name' => __( 'Footer Area One'),
		'description' => __( 'An optional widget area for your site footer' ),
		'before_widget' => '<div id="%1$s" class="widget %2$s">',
		'after_widget' => '</div>',
		'before_title' => '<h2 class="widgettitle">',
		'after_title' => '</h2>',
	) );
}
if ( function_exists ('register_sidebar')) {
	register_sidebar( array(
		'name' => __( 'Footer Area Two' ),
		'description' => __( 'An optional widget area for your site footer' ),
		'before_widget' => '<div id="%1$s" class="widget %2$s">',
		'after_widget' => "</div>",
		'before_title' => '<h2 class="widgettitle">',
		'after_title' => '</h2>',
	) );
}
 //--------------CUSTOM BANNER----------------------------	
add_action( 'after_setup_theme', 'add_banner' );

if ( !function_exists( 'add_banner' ) ):
function add_banner() {

	register_sidebar( array(
		'name' => __( 'Horizontal Banner Area', 'project3' ),
		'id' => 'horizontal-1',
		'description' => __( 'An optional banner area', 'project3' ),
		'before_widget' =>'<div id="banner">',
		'after_widget'  => '</div>',   
	) );
}
endif;	

 //--------------MENU----------------------------    
 register_nav_menu('main-menu', "This is my top site menu");   



 //--------------COMMENTS----------------------------
if ( ! function_exists( 'project3_comment' ) ) :

function project3_comment( $comment, $args, $depth ) {
	$GLOBALS['comment'] = $comment;
	switch ( $comment->comment_type ) :
		case '' :
	?>

<li <?php comment_class(); ?> id="li-comment-<?php comment_ID(); ?>">
  <div id="comment-<?php comment_ID(); ?>">
    <div class="comment-gravatar"><?php echo get_avatar( $comment, 65 ); ?></div>
    <div class="comment-body">
      <div class="comment-meta commentmetadata"> <?php printf( __( '%s', 'project3' ), sprintf( '<cite class="fn">%s</cite>', get_comment_author_link() ) ); ?><br/>
        <a href="<?php echo esc_url( get_comment_link( $comment->comment_ID ) ); ?>">
        <?php
				/* translators: 1: date, 2: time */
				printf( __( '%1$s at %2$s', 'project3' ), get_comment_date(),  get_comment_time() ); ?>
        </a>
        <?php edit_comment_link( __( 'Edit &rarr;', 'project3' ), ' ' );
			?>
      </div>
      <!-- .comment-meta .commentmetadata -->
      
      <?php comment_text(); ?>
      <?php if ( $comment->comment_approved == '0' ) : ?>
      <p class="moderation">
        <?php _e( 'Your comment is awaiting moderation.', 'project3' ); ?>
      </p>
      <?php endif; ?>
      <div class="reply">
        <?php comment_reply_link( array_merge( $args, array( 'depth' => $depth, 'max_depth' => $args['max_depth'] ) ) ); ?>
      </div>
      <!-- .reply --> 
      
    </div>
    <!--comment Body--> 
    
  </div>
  <!-- #comment-##  -->
  
  <?php
			break;
		case 'pingback'  :
		case 'trackback' :
	?>
<li class="post pingback">
  <p>
    <?php _e( 'Pingback:', 'project3' ); ?>
    <?php comment_author_link(); ?>
    <?php edit_comment_link( __('(Edit)', 'project3'), ' ' ); ?>
  </p>
  <?php
			break;
	endswitch;
}
endif;
 //--------------End of comments----------------------------
 add_theme_support( 'post-thumbnails');
 
 
 
//--------------Display navigation to next/previous pages when applicable---------------------------- 

if ( !function_exists( 'project3_content_nav' ) ) :
function project3_content_nav( $html_id ) {
	global $wp_query;

	if ( $wp_query->max_num_pages > 1 ) : ?>
  <nav id="<?php echo esc_attr( $html_id ); ?>">
    <div class="nav-previous">
      <?php next_posts_link( __( '<span class="meta-nav">&laquo;</span> Older posts', 'project3' ) ); ?>
    </div>
    <div class="nav-next">
      <?php previous_posts_link( __( 'Newer posts <span class="meta-nav">&raquo;</span>', 'project3' ) ); ?>
    </div>
  </nav>
  <!-- #nav-above -->
  <?php  endif;
}
endif; // project3_content_nav
 ?>
  <?php 
  
  
//--------------Filter for atribute rel in category link element----------------------------
function ispireme_fix_category_tag ($ispireme_cat_output) {
$ispireme_cat_output = str_replace(array('rel="category tag"','rel="category"'),'', $ispireme_cat_output);

return $ispireme_cat_output;
}
add_filter( 'the_category', 'ispireme_fix_category_tag' );
?>
  <?php
  //--------------Custom Excerpt length----------------------------
function custom_excerpt_length( $length ) {
	return 85;
}
add_filter( 'excerpt_length', 'custom_excerpt_length', 999 );
?>
