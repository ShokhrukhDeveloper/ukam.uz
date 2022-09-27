import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:referat/presentation/pages/home_page/category_row_widget/category_row_widget.dart';
import 'package:referat/presentation/widget/appbar_widget/appbar_widget.dart';
import 'package:referat/presentation/widget/category_result_widget/category_result_widget.dart';

import '../../../app_colors/app_text_styles.dart';
import 'product_details.dart';

class ProductPage extends StatefulWidget {
  const ProductPage({Key? key}) : super(key: key);

  @override
  State<ProductPage> createState() => _ProductPageState();
}

class _ProductPageState extends State<ProductPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        children:  const [
          AppBarWidget(),
          CategoryResultWidget(),
          ProductDetails()
          // Container(
          //   margin: const EdgeInsets.only(left: 20,right: 10,top: 15),
          //   child: LayoutBuilder(
          //     builder: (context,constrains) {
          //       return  SizedBox(
          //         height: 300,
          //         child: Row(
          //           mainAxisAlignment: MainAxisAlignment.start,
          //           children: [
          //             //image picture
          //               Container(
          //                 margin:EdgeInsets.only(),
          //                 child: ClipRRect(
          //                   borderRadius: BorderRadius.circular(14),
          //                   child: CachedNetworkImage(
          //                     imageUrl: "https://picsum.photos/200/300",
          //                     width: 200,
          //                     height: 350,
          //                     fit: BoxFit.cover,
          //                   ),
          //                 ),
          //               ),
          //             SizedBox(width: 10,),
          //             Column(
          //               mainAxisAlignment: MainAxisAlignment.start,
          //               crossAxisAlignment: CrossAxisAlignment.start,
          //               children: [
          //                 SizedBox(
          //                   width:constrains.maxWidth-215,
          //                   child: const Text("Даниел КИЗdcasdsasdasd-",
          //                     style: AppTextStyles.text24W500Black,
          //                     maxLines: 1,
          //                     overflow: TextOverflow.ellipsis,
          //                   ),
          //
          //                 ),
          //                 SizedBox(
          //                   child: Row(
          //
          //                   ),
          //                 )
          //               ],
          //             )
          //
          //           ],
          //         ),
          //       );
          //     }
          //   ),
          // )
        ],
      ),
    );
  }
}
