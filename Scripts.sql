c r e a t e   d a t a b a s e   h a i r _ s a l o n  
 g o  
 U S E   [ h a i r _ s a l o n ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ c l i e n t s ]         S c r i p t   D a t e :   3 / 8 / 2 0 1 6   8 : 0 8 : 1 7   P M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ c l i e n t s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ s t y l i s t _ i d ]   [ i n t ]   N U L L  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ s t y l i s t s ]         S c r i p t   D a t e :   3 / 8 / 2 0 1 6   8 : 0 8 : 1 7   P M   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ s t y l i s t s ] (  
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ c l i e n t s ]   O N    
  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 1 ,   N ' T e s t i n g ' ,   2 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 2 ,   N ' s s d s a s d ' ,   2 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 3 ,   N ' a s s a d a s d s d a s ' ,   2 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 4 ,   N ' s s a d d s d ' ,   2 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 5 ,   N ' T e s t i n g a l l ' ,   1 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 6 ,   N ' ' ,   2 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 7 ,   N ' ' ,   1 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 8 ,   N ' d f s s d f f s s f d ' ,   5 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 9 ,   N ' s d f d s f s d f d s s d d f s ' ,   5 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 1 0 ,   N ' P h i l l i s ' ,   4 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 1 1 ,   N ' a d s d s a d s a s d s d a a s d s a d s d a ' ,   2 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 1 2 ,   N ' s f d f d s ' ,   1 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 1 3 ,   N ' s a d d s a d s a ' ,   1 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 1 4 ,   N ' d s a d s a d a s d a s d a s d s d a s d a s ' ,   7 )  
 I N S E R T   [ d b o ] . [ c l i e n t s ]   ( [ i d ] ,   [ n a m e ] ,   [ s t y l i s t _ i d ] )   V A L U E S   ( 1 5 ,   N ' a s a s d ' ,   8 )  
 S E T   I D E N T I T Y _ I N S E R T   [ d b o ] . [ c l i e n t s ]   O F F  
 
