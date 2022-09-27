import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:referat/presentation/widget/comment_badge_widget.dart';

import '../../../app_colors/app_colors.dart';
import '../../../app_colors/app_text_styles.dart';
import '../filtr/filtr_list_widget/serach_item_list_widget.dart';

class ProductDetails extends StatelessWidget {
  const ProductDetails({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(left: 20,right: 10,top: 15),
      child: LayoutBuilder(
          builder: (context,constrains) {
            return  SizedBox(
              height: 350,
              child: Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  //image picture
                  //w200
                  ClipRRect(
                    borderRadius: BorderRadius.circular(14),
                    child: CachedNetworkImage(
                      imageUrl: "https://picsum.photos/200/300",
                      width: 200,
                      height: 350,
                      fit: BoxFit.cover,
                    ),
                  ),
                  //w10
                  const SizedBox(width: 20),
                  Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      //h50
                      SizedBox(
                        height: 50,
                        child: Row(
                          children: [
                            //
                            SizedBox(
                              width:constrains.maxWidth-410,
                              child: const Text("Даниел КИЗdcasdsasdasd-",
                                style: AppTextStyles.text24W500Black,
                                maxLines: 1, overflow: TextOverflow.ellipsis,),),
                            //w190
                            SizedBox(
                              width: 190,
                              child: Row(
                              children:  [
                                Icon(Icons.star,color: AppColors.secondary, size: 20,),
                                SizedBox(width:1 ,),
                                Icon(Icons.star,color: AppColors.secondary, size: 20,),
                                SizedBox(width:1 ,),
                                Icon(Icons.star,color: AppColors.secondary, size: 20,),
                                SizedBox(width:1 ,),
                                Icon(Icons.star,color: AppColors.secondary, size: 20,),
                                SizedBox(width:1 ,),
                                Icon(Icons.star,color: AppColors.secondary, size: 20,),
                                SizedBox(width:1 ,),
                                Text("4.7", style: AppTextStyles.text28W700Style),
                                const SizedBox(width: 10,),
                                const CommentBadge(),
                                const SizedBox(width: 15,),
                                const Icon(Icons.bookmark_border_outlined,size: 20,color: AppColors.gray,),
                                const SizedBox(width: 5,),
                              ],
                              ),
                            ),



                          ],
                        ),
                      ),
                      //h20
                      Container(
                        height: 20,
                        width:constrains.maxWidth-400,
                        child: Text(
                          "SIYOSAT, FANTASTIKA ",
                          overflow: TextOverflow.ellipsis,
                          style: AppTextStyles.text14W400Style,),
                      ),
                      //h130
                      SizedBox(
                          height: 130,
                            width: constrains.maxWidth-250,
                            child:  Text(
                            txt+
                            txt+
                            txt+
                            txt+
                              txt,
                            overflow: TextOverflow.ellipsis,
                            style: AppTextStyles.text8W400StyleContent,
                            maxLines: 9,
                            )),
                      //h20
                      const SizedBox(height: 20,),
                      //h40
                      SizedBox(
                        height: 40,
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.start,
                          crossAxisAlignment: CrossAxisAlignment.stretch,
                          children: [
                            SizedBox(
                              width: 100,
                              child: Column
                                (
                                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                children: const [
                                  SizedBox(width: 100,
                                    child: Text("Muallifi:",
                                      textAlign: TextAlign.left,
                                      overflow: TextOverflow.ellipsis,
                                      style: AppTextStyles.text10W400StyleGray,
                                    ),
                                  ),
                                  SizedBox(width: 100,
                                    child: Text(
                                      "Kevin Smileya sdfasf asdfasdgfasdgasgdasdg ",
                                      textAlign: TextAlign.left,
                                      overflow: TextOverflow.ellipsis,
                                      style: AppTextStyles.text14W400StyleBlack,
                                    ),
                                  )
                                ],
                              ) ,
                            ),
                            SizedBox(
                              width: 100,
                              child: Column
                                (
                                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                children: const [
                                  SizedBox(width: 100,
                                    child: Text("Nashriyot:",
                                      textAlign: TextAlign.left,
                                      overflow: TextOverflow.ellipsis,
                                      style: AppTextStyles.text10W400StyleGray,
                                    ),
                                  ),
                                  SizedBox(width: 100,
                                    child: Text(
                                      "Panda Studios ",
                                      textAlign: TextAlign.left,
                                      overflow: TextOverflow.ellipsis,
                                      style: AppTextStyles.text14W400StyleBlack,
                                    ),
                                  )
                                ],
                              ) ,
                            ),
                            SizedBox(
                              width: 100,
                              child: Column
                                (
                                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                children: const [
                                  SizedBox(width: 100,
                                    child: Text("Yili:",
                                      textAlign: TextAlign.left,
                                      overflow: TextOverflow.ellipsis,
                                      style: AppTextStyles.text10W400StyleGray,
                                    ),
                                  ),
                                  SizedBox(width: 100,
                                    child: Text(
                                      "2022",
                                      textAlign: TextAlign.left,
                                      overflow: TextOverflow.ellipsis,
                                      style: AppTextStyles.text14W400StyleBlack,
                                    ),
                                  )
                                ],
                              ) ,
                            ),
                          ],
                        ),
                      ),

                      SizedBox(
                        height: 80,
                        width: 400,
                        child:

                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            FloatingActionButton.extended(onPressed: (){}, label: Row(
                              children: [
                                Icon(Icons.local_taxi_outlined), Text("Sotib olish",

                                style: AppTextStyles.text16W500White,)
                              ],
                            )),
                            FloatingActionButton.extended(
                              backgroundColor: AppColors.white,
                                onPressed: (){},

                                label: Row(
                              children: const [
                                Icon(Icons.download,color: AppColors.black,), Text("Yuklab olish",style: AppTextStyles.text16W500Black,)
                              ],
                            )),
                          ],
                        ),
                      )



                    ],
                  )

                ],
              ),
            );
          }
      ),
    );
  }
}
