import 'package:flutter/material.dart';
import 'package:referat/app_colors/app_colors.dart';
import 'package:referat/app_colors/app_text_styles.dart';
class FilterHeaderWidget extends StatefulWidget {
   FilterHeaderWidget({Key? key, required this.width, required this.list, this.onTap}) : super(key: key);
 final double width;
 final bool list;
 final Function(bool list)? onTap;

  @override
  State<FilterHeaderWidget> createState() => _FilterHeaderWidgetState();
}

class _FilterHeaderWidgetState extends State<FilterHeaderWidget> {
  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(left: 10,right: 10,top: 0),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(14),
        border: Border.all(color: AppColors.borderGray)),
      height: 40,
      width: widget.width<410?widget.width-400:widget.width+5,
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.center,
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children:  [
          const Text("    Kitoblar",
            style: AppTextStyles.text16W500Black,
          ),
          Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              IconButton(onPressed:()=>widget.onTap!(widget.list),icon:  Icon(Icons.grid_view_sharp,color: widget.list?null:AppColors.primary,)),
              IconButton(onPressed:()=>widget.onTap!(widget.list),icon: Icon(Icons.table_rows_rounded,color: widget.list?AppColors.primary:null,)),
            ],
          ),


        ],
      )
    );
  }
}
