	     </div>
       </div>
    <footer>
      <p>Copyright &copy; CSS3_seascape_two | <a href="http://www.css3templates.co.uk">design from css3templates.co.uk</a></p>
    </footer>
  </div>
  <p>&nbsp;</p>
  <!-- javascript at the bottom for fast page loading -->
  <script type="text/javascript" src="<?php bloginfo('template_url'); ?>/js/jquery.js"></script>
  <script type="text/javascript" src="<?php bloginfo('template_url'); ?>/js/jquery.easing-sooper.js"></script>
  <script type="text/javascript" src="<?php bloginfo('template_url'); ?>/js/jquery.sooperfish.js"></script>
  <script type="text/javascript" src="<?php bloginfo('template_url'); ?>/js/jquery.kwicks-1.5.1.js"></script>

  <script type="text/javascript">
    $(document).ready(function() {
      $('#images').kwicks({
        max : 600,
        spacing : 2
      });
      $('ul.sf-menu').sooperfish();
    });
  </script>
<?php wp_footer(); ?>  
</body>
</html>
