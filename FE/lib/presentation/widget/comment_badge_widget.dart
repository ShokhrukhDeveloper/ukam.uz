import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../app_colors/app_colors.dart';

class CommentBadge extends StatelessWidget {
  const CommentBadge({Key? key}) : super(key: key);
  final int value=9;
  @override
  Widget build(BuildContext context) {

      return SizedBox(
        width: 15,
        height: 15,
        child:Stack(

          children:  [
            Align(
                alignment: Alignment.center,
                child: Icon(CupertinoIcons.chat_bubble_fill,size:20,color: AppColors.gray.withOpacity(0.5))),
            Positioned(
                top: 4,
                right: 0,
                child: Text("9+",textAlign:TextAlign.center,style: TextStyle(color: Colors.red,fontSize: 8,fontWeight: FontWeight.bold),))

          ],
        ),
      );

  }
}
