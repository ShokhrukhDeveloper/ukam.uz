import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';

import '../../../../app_colors/app_colors.dart';
import '../../../../app_colors/app_text_styles.dart';
class SimilarWidget extends StatelessWidget {
  const SimilarWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return  Container(
      margin: EdgeInsets.symmetric(horizontal: 12.0),
      child: Row(
        children: [
          Container(
            width: 100,
            height: 150,
            decoration: BoxDecoration(
                border: Border.all(color: AppColors.grey),
                borderRadius: BorderRadius.circular(14),
                image: DecorationImage(
                    image: CachedNetworkImageProvider("https://picsum.photos/200/300"),
                    fit: BoxFit.cover
                )
            ),
          ),
          SizedBox(width: 15,),
          SizedBox(
            height: 150,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Container(
                  padding: EdgeInsets.only(top:5),
                  width: 180,
                  child: Text("Элжернга аталган гуллар ba]sd asdk asjdnkks  asdfp asdfouasdfasdf asdf asdf asd",
                    maxLines: 2,
                    overflow: TextOverflow.ellipsis,
                    style: AppTextStyles.text14BoldStyleBlack,
                  ),
                ),
                SizedBox(
                  width: 180,
                  child: Text("SIYOSAT, FANTASTIKA",
                    overflow: TextOverflow.ellipsis,
                    style: AppTextStyles.text14W400StyleGrey,
                  ),),
                SizedBox(
                  height: 40,width: 180,
                  child: Row(
                    mainAxisSize: MainAxisSize.min,
                    children: const [
                      Icon(Icons.star,color: AppColors.secondary, size: 20,),
                      SizedBox(width:5 ,),
                      Text("4.7",
                        style: AppTextStyles.text28W700Style,
                      ),
                      SizedBox(width: 15,),
                      SizedBox(
                        width: 100,
                        child: Text("244 fikrlar",
                          overflow: TextOverflow.ellipsis,
                          style: AppTextStyles.text14W400StyleGrey,
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          )
        ],
      ),
    );
  }
}
