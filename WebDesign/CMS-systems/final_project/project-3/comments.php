<?php
/**
Template Name: Comments Template
 */
?>

<div id="comments"  class="clearfix">
  <?php if ( post_password_required() ) : ?>
  <div class="nopassword">
    <?php _e( 'This post is password protected. Enter the password to view any comments.', 'project3' ); ?>
  </div>
</div>
<!-- end comments -->
<?php
		return;
	endif;
?>
<?php
	// You can start editing here -- including this comment!
?>
<?php if ( have_comments() ) : ?>
<h3 id="comments-title">
  <?php
			printf( _n( 'One Comment', '%1$s Comments', get_comments_number(), 'project3' ),
			number_format_i18n( get_comments_number() ));
			?>
</h3>
<p class="write-comment-link"><a href="#respond">
  <?php _e( 'Leave a reply &rarr;', 'project3' ); ?>
  </a></p>
<ol class="commentlist">
  <?php wp_list_comments( array( 'callback' => 'project3_comment' ) ); ?>
</ol>
<?php if ( get_comment_pages_count() > 1 && get_option( 'page_comments' ) ) : // are there comments to navigate through ?>
<nav id="comment-nav-below">
  <div class="nav-previous">
    <?php previous_comments_link( __( '&larr; Older Comments', 'project3' ) ); ?>
  </div>
  <div class="nav-next">
    <?php next_comments_link( __( 'Newer Comments &rarr;', 'project3' ) ); ?>
  </div>
</nav>
<?php endif; // check for comment navigation ?>
<?php else : // this is displayed if there are no comments so far ?>
<?php if ( comments_open() ) : // If comments are open, but there are no comments ?>
<?php else : // or, if we don't have comments:
		
			/* If there are no comments and comments are closed,
			 * let's leave a little note, shall we?
			 * But only on posts! We don't want the note on pages.
			 */
			if ( ! comments_open() && ! is_page() ) :
			?>
<p class="nocomments">
  <?php _e( 'Comments are closed.', 'project3' ); ?>
</p>
<?php endif; // end ! comments_open() && ! is_page() ?>
<?php endif; ?>
<?php endif; ?>
<?php comment_form(
array(
	'comment_notes_before' =>__( '<p class="comment-notes">Required fields are marked <span class="required">*</span>.</p>', 'project3'),
	'comment_notes_after' => '',
	'comment_field'  => '<p class="comment-form-comment"><label for="comment">' . _x( 'Message <span class="required">*</span>', 'noun', 'project3' ) . 	'</label><br/><textarea id="comment" name="comment" rows="8"></textarea></p>',
)
); ?>
</div>
<!-- end comments -->